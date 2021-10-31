using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
    public partial class frmMaintenance : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmMaintenance()
        {
            InitializeComponent();
        }
        private void frmMaintenance_Load(object sender, EventArgs e)
        {
            mnpltDataGridAlert();
            loadDataAlert();

            mnpltDataGridCertificates();
            loadDataCertificates();

            mnpltDataGridCivil();
            loadDataCivil();

            mnpltDataGridDelivery();
            loadDataDelivery();

            mnpltDataGridGender();
            loadDataGender();

            mnpltDataGridItems();
            loadDataItems();

            mnpltDataGridPurok();
            loadDataPurok();
        }

        // NO. 1 //
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


        // NO. 2 //
        private void mnpltDataGridCertificates()
        {
            mtrData2.Rows.Clear();
            mtrData2.Columns.Clear();

            mtrData2.Columns.Add("no", "No.");
            mtrData2.Columns.Add("id", "ID.");
            mtrData2.Columns.Add("typs", "Types");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData2.Columns.Add(btn1);
        }

        private async void loadDataCertificates()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_certificates.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["certificates"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_certificate"]);
                        AL.Add(jo["Types"]);
                        mtrData2.Rows.Add(AL.ToArray());
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


        // NO. 3 //
        private void mnpltDataGridCivil()
        {
            mtrData3.Rows.Clear();
            mtrData3.Columns.Clear();

            mtrData3.Columns.Add("no", "No.");
            mtrData3.Columns.Add("id", "ID.");
            mtrData3.Columns.Add("typs", "Types");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData3.Columns.Add(btn1);
        }

        private async void loadDataCivil()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_civilstatus.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["civil"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_civilstatus"]);
                        AL.Add(jo["Types"]);
                        mtrData3.Rows.Add(AL.ToArray());
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


        // NO. 4 //
        private void mnpltDataGridDelivery()
        {
            mtrData4.Rows.Clear();
            mtrData4.Columns.Clear();

            mtrData4.Columns.Add("no", "No.");
            mtrData4.Columns.Add("id", "ID.");
            mtrData4.Columns.Add("opt", "Options");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData4.Columns.Add(btn1);
        }

        private async void loadDataDelivery()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_deliveryoptions.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["deliveryoptions"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_deliveryoption"]);
                        AL.Add(jo["Options"]);
                        mtrData4.Rows.Add(AL.ToArray());
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


        // NO. 5 //
        private void mnpltDataGridGender()
        {
            mtrData5.Rows.Clear();
            mtrData5.Columns.Clear();

            mtrData5.Columns.Add("no", "No.");
            mtrData5.Columns.Add("id", "ID.");
            mtrData5.Columns.Add("idt", "Identities");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData5.Columns.Add(btn1);
        }

        private async void loadDataGender()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_gender.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["gender"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_gender"]);
                        AL.Add(jo["Identities"]);
                        mtrData5.Rows.Add(AL.ToArray());
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

        // NO. 6 //
        private void mnpltDataGridItems()
        {
            mtrData6.Rows.Clear();
            mtrData6.Columns.Clear();

            mtrData6.Columns.Add("no", "No.");
            mtrData6.Columns.Add("id", "ID.");
            mtrData6.Columns.Add("itm", "Item Name");
            mtrData6.Columns.Add("quan", "Quantity");
            mtrData6.Columns.Add("tquan", "Total Quantity");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData6.Columns.Add(btn1);
        }



        private async void loadDataItems()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_items.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["items"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_items"]);
                        AL.Add(jo["ItemName"]);
                        AL.Add(jo["Quantity"]);
                        AL.Add(jo["TotalQuantity"]);
                        mtrData6.Rows.Add(AL.ToArray());
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

        // NO. 7 //
        private void mnpltDataGridPurok()
        {
            mtrData7.Rows.Clear();
            mtrData7.Columns.Clear();

            mtrData7.Columns.Add("no", "No.");
            mtrData7.Columns.Add("id", "ID.");
            mtrData7.Columns.Add("prk", "Name");

            DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            btn1.HeaderText = "Action";
            btn1.Name = "btnGenerate";
            btn1.Text = "View/Edit";
            btn1.UseColumnTextForButtonValue = true;
            mtrData7.Columns.Add(btn1);
        }



        private async void loadDataPurok()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_purok.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["purok"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_purok"]);
                        AL.Add(jo["Name"]);
                        mtrData7.Rows.Add(AL.ToArray());
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

        private void metroData1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mtrData1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
