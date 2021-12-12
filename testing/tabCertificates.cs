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
    public partial class tabCertificates : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";
        public tabCertificates()
        {
            InitializeComponent();
        }

        private void tabCertificates_Load(object sender, EventArgs e)
        {
            mnpltDataGridCertificates();
            loadDataCertificates();
        }

        private void mnpltDataGridCertificates()
        {
            mtrData2.Rows.Clear();
            mtrData2.Columns.Clear();

            mtrData2.Columns.Add("no", "No.");
            mtrData2.Columns.Add("id", "ID.");
            mtrData2.Columns.Add("typs", "Types");
            mtrData2.Columns.Add("docfee", "Document Fee");
            mtrData2.Columns.Add("delfee", "Delivery Fee");

            //DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            //btn1.HeaderText = "Action";
            //btn1.Name = "btnGenerate";
            //btn1.Text = "View/Edit";
            //btn1.UseColumnTextForButtonValue = true;
            //mtrData2.Columns.Add(btn1);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            mtrData2.Columns.Add(btn);

            mtrData2.Columns["id"].Visible = false;
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
                        AL.Add(jo["DocFee"]);
                        AL.Add(jo["DeliveryFee"]);
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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTypes.Text != "" && tbDocFee.Text != "" && tbDelivery.Text != "")
                {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_certificates_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Types"] = tbTypes.Text;
                        datas["DocFee"] = tbDocFee.Text;
                        datas["DeliveryFee"] = tbDelivery.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        ID = "";
                        tbTypes.Text = "";
                        tbDocFee.Text = "";
                        tbDelivery.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else{
                    MessageBox.Show("Please fill up all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData2.Rows.Clear();
                loadDataCertificates();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != "" && tbTypes.Text != "" && tbDocFee.Text !="" && tbDelivery.Text !="") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_certificates_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Types"] = tbTypes.Text;
                        datas["DocFee"] = tbDocFee.Text;
                        datas["DeliveryFee"] = tbDelivery.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        ID = "";
                        tbTypes.Text = "";
                        tbDocFee.Text = "";
                        tbDelivery.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Update Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to Update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData2.Rows.Clear();
                loadDataCertificates();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID !="") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_certificates_delete.php";

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
                        tbTypes.Text = "";
                        tbDocFee.Text = "";
                        tbDelivery.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Unable to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                mtrData2.Rows.Clear();
                loadDataCertificates();
            }
        }

        private void mtrData2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    DataGridViewRow row = mtrData2.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData2.Rows.Clear();
                    loadDataCertificates();
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

                var uri = host.IP() + "/iBar/ibar_certificates_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["cert"])
                    {
                        tbTypes.Text = jo["Types"].ToString();
                        tbDocFee.Text = jo["DocFee"].ToString();
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

    }
}
