using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;

namespace testing
{
    public partial class tabGender : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";

        public tabGender()
        {
            InitializeComponent();
        }

        private void tabGender_Load(object sender, EventArgs e)
        {
            mnpltDataGridGender();
            loadDataGender();
        }


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


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_gender_insert.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Identities"] = tbIdentities.Text;

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData5.Rows.Clear();
                loadDataGender();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_gender_update.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["ID"] = ID;
                    datas["Identities"] = tbIdentities.Text;

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
                mtrData5.Rows.Clear();
                loadDataGender();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_gender_delete.php";

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
                mtrData5.Rows.Clear();
                loadDataGender();
            }
        }

        private void mtrData5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = mtrData5.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData5.Rows.Clear();
                    loadDataGender();
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

                var uri = host.IP() + "/iBar/ibar_gender_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["gender"])
                    {
                        tbIdentities.Text = jo["Identities"].ToString();
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
