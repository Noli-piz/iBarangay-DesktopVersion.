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
    public partial class tabCivilStatus : Form
    {

        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";

        public tabCivilStatus()
        {
            InitializeComponent();
        }

        private void tabCivilStatus_Load(object sender, EventArgs e)
        {
            mnpltDataGridCivil();
            loadDataCivil();
        }

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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbTypes.Text != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_civilstatus_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Types"] = tbTypes.Text;

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
                    MessageBox.Show("Please enter a name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData3.Rows.Clear();
                loadDataCivil();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_civilstatus_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Types"] = tbTypes.Text;

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
                mtrData3.Rows.Clear();
                loadDataCivil();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_civilstatus_delete.php";

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
                mtrData3.Rows.Clear();
                loadDataCivil();
            }
        }

        private void mtrData3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = mtrData3.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData3.Rows.Clear();
                    loadDataCivil();
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
            MessageBox.Show(id + "");

            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_civilstatus_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["civil"])
                    {

                        tbTypes.Text = jo["Types"].ToString();
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
