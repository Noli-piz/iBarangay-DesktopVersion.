using MySql.Data.MySqlClient;
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
    public partial class frmAppointment : Form
    {

        csHostConfiguration host = new csHostConfiguration();
        List<string> ID = new List<string>();

        public frmAppointment()
        {
            InitializeComponent();
        }

        private void frmAppointment_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            LoadData();
        }

        private void mnpltDataGrid()
        {
            //ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();
            data1.Visible = false;

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("title", "Title");
            data1.Columns.Add("name", "Name");
            data1.Columns.Add("det", "Details");
            data1.Columns.Add("date", "Date");
            data1.Columns.Add("stime", "Start Time");
            data1.Columns.Add("etime", "End Time");
            data1.Columns.Add("stat", "Status");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View/Edit";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        private async void LoadData()
        {
            try
            {

                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_appointment.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();

                List<int> colorInt = new List<int>();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["appointment"])
                    {
                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_appointment"]);
                        ID.Add(jo["id_appointment"].ToString());
                        AL.Add(jo["Title"]);
                        AL.Add(jo["Name"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Date"]);
                        AL.Add(jo["StartTime"]);
                        AL.Add(jo["EndTime"]);
                        AL.Add(jo["Status"]);
                        if (jo["Status"].ToString() == "True")
                        {
                            colorInt.Add(i);
                        }
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }

                    
                    for (int x = 0; x < data1.Rows.Count; x++)
                    {
                        if ( colorInt.Contains(x))
                        {
                            data1.Rows[x-1].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        }
                    }


                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }



                data1.AutoResizeColumns();
                data1.AutoResizeRows();

                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                data1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_appointment_insert.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Title"] = tbTitle.Text;
                    datas["Name"] = tbName.Text;
                    datas["Details"] = rbDetails.Text;
                    datas["Date"] = dtDate.Value.ToString("yyyy-MM-dd");
                    datas["EndTime"] = dtTimeEnd.Value.ToString("hh:mm:ss tt");
                    datas["StartTime"] = dtTimeStart.Value.ToString("hh:mm:ss tt");
                    datas["Status"] = cbDone.Checked ? "True" : "False";

                    csUser user = new csUser();
                    datas["UserID"] = user.strID();

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
                ID.Clear();
                data1.Rows.Clear();
                LoadData();
                btnClear_Click(sender, e);
            }
        }

        private void data1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 9)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    frmAppointment_update frm = new frmAppointment_update(identifier);
                    frm.ShowDialog(this);

                    ID.Clear();
                    data1.Rows.Clear();
                    LoadData();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control field in frmAppointment.ActiveForm.Controls)
            {
                if (field is TextBox)
                    ((TextBox)field).Clear();
                if (field is RichTextBox)
                    ((RichTextBox)field).Clear();
                if (field is CheckBox)
                    ((CheckBox)field).Checked = false;
            }
        }
    }
}
