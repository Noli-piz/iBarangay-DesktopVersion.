
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using System.Collections.Specialized;
using System.Net;

namespace testing
{
    public partial class tabItems : Form 
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";

        public tabItems()
        {
            InitializeComponent();
        }

        private void tabItems_Load(object sender, EventArgs e)
        {
            mnpltDataGridItems();
            loadDataItems();
        }

        private void mnpltDataGridItems()
        {
            mtrData6.Rows.Clear();
            mtrData6.Columns.Clear();

            mtrData6.Columns.Add("no", "No.");
            mtrData6.Columns.Add("id", "ID.");
            mtrData6.Columns.Add("itm", "Item Name");
            mtrData6.Columns.Add("quan", "Quantity");
            mtrData6.Columns.Add("tquan", "Total Quantity");
            mtrData6.Columns.Add("dfee", "DeliveryFee");

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
                        AL.Add(jo["DeliveryFee"]);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbItemName.Text != "" && tbDelivery.Text != "" && tbQuantity.Text != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_items_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Items"] = tbItemName.Text;
                        datas["Quantity"] = tbQuantity.Text;
                        datas["DeliveryFee"] = tbDelivery.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Add.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData6.Rows.Clear();
                loadDataItems();
            }
        }

        private void mtrData6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    DataGridViewRow row = mtrData6.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData6.Rows.Clear();
                    loadDataItems();
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

                var uri = host.IP() + "/iBar/ibar_items_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["item"])
                    {

                        //jo["id_announcement"];
                        tbItemName.Text = jo["ItemName"].ToString();
                        tbQuantity.Text = jo["Quantity"].ToString();
                        tbDelivery.Text = jo["DeliveryFee"].ToString();
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



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_items_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Items"] = tbItemName.Text;
                    datas["Quantity"] = tbQuantity.Text;
                    datas["DeliveryFee"] = tbDelivery.Text;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                if (responseFromServer == "Operation Success")
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed " + responseFromServer);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData6.Rows.Clear();
                loadDataItems();
            }
        }
        
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_items_delete.php";

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
                mtrData6.Rows.Clear();
                loadDataItems();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
