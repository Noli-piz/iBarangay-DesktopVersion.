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
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class tabPurok : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private string ID = "";
        public tabPurok()
        {
            InitializeComponent();
        }

        private void tabPurok_Load(object sender, EventArgs e)
        {
            mnpltDataGridPurok();
            loadDataPurok();
        }

        private void mnpltDataGridPurok()
        {
            mtrData7.Rows.Clear();
            mtrData7.Columns.Clear();

            mtrData7.Columns.Add("no", "No.");
            mtrData7.Columns.Add("id", "ID.");
            mtrData7.Columns.Add("prk", "Name");

            //DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
            //btn1.HeaderText = "Action";
            //btn1.Name = "btnGenerate";
            //btn1.Text = "View/Edit";
            //btn1.UseColumnTextForButtonValue = true;
            //mtrData7.Columns.Add(btn1);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            mtrData7.Columns.Add(btn);

            mtrData7.Columns["id"].Visible = false;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbName.Text != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_purok_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["Purok"] = tbName.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        tbName.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a purok name.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mtrData7.Rows.Clear();
                loadDataPurok();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID !="" && tbName.Text != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_purok_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = ID;
                        datas["Purok"] = tbName.Text;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        ID = "";
                        tbName.Text = "";
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
                mtrData7.Rows.Clear();
                loadDataPurok();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID != "") {
                    DateTime dateToday = DateTime.Now;

                    var uri = host.IP() + "/iBar/ibar_purok_delete.php";

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
                        tbName.Text = "";
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
                mtrData7.Rows.Clear();
                loadDataPurok();
            }
        }

        private void mtrData7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    DataGridViewRow row = mtrData7.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    LoadSpecific(identifier);

                    mtrData7.Rows.Clear();
                    loadDataPurok();
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

                var uri = host.IP() + "/iBar/ibar_purok_specific.php";

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
                    foreach (var jo in (JArray)((JObject)data)["purok"])
                    {
                        tbName.Text = jo["Name"].ToString();
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
