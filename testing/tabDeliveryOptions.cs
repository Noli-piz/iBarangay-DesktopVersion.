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
using System.Net;
using System.Collections.Specialized;

namespace testing
{
    public partial class tabDeliveryOptions : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";

        public tabDeliveryOptions()
        {
            InitializeComponent();
        }

        private void tabDeliveryOptions_Load(object sender, EventArgs e)
        {
            mnpltDataGridDelivery();
            loadDataDelivery();
        }


        private void mnpltDataGridDelivery()
        {
            mtrData4.Rows.Clear();
            mtrData4.Columns.Clear();

            mtrData4.Columns.Add("no", "No.");
            mtrData4.Columns.Add("id", "ID.");
            mtrData4.Columns.Add("opt", "Options");

            //DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            //btn1.HeaderText = "Action";
            //btn1.Name = "btnGenerate";
            //btn1.Text = "View/Edit";
            //btn1.UseColumnTextForButtonValue = true;
            //mtrData4.Columns.Add(btn1);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            mtrData4.Columns.Add(btn);

            mtrData4.Columns["id"].Visible = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_deliveryoptions_insert.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Options"] = tbDeliveryOpt.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Insert Successfully");
                    ID = "";
                    tbDeliveryOpt.Text = "";
                }
                else
                {
                    MessageBox.Show("Insert Failed " + responseFromServer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData4.Rows.Clear();
                loadDataDelivery();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_deliveryoptions_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Option"] = tbDeliveryOpt.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Update Successfully");
                    ID = "";
                    tbDeliveryOpt.Text = "";
                }
                else
                {
                    MessageBox.Show(responseFromServer);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData4.Rows.Clear();
                loadDataDelivery();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_deliveryoptions_delete.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Delete Successfully");
                    ID = "";
                    tbDeliveryOpt.Text = "";
                }
                else
                {
                    MessageBox.Show("Delete Failed " + responseFromServer);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData4.Rows.Clear();
                loadDataDelivery();
            }
        }

        private void mtrData4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = mtrData4.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData4.Rows.Clear();
                    loadDataDelivery();
                }
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void LoadSpecific(String id)
        {
            ID = id;

            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_deliveryoptions_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["opt"])
                    {
                        tbDeliveryOpt.Text = jo["Options"].ToString();
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
