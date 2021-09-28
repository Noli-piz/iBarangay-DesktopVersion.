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
    public partial class frmAnnouncement : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmAnnouncement()
        {
            InitializeComponent();
        }

        private void frmAnnouncement_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData();
            LoadCombobox();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();
            data1.Visible = false;

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("sbjct", "Subject");
            data1.Columns.Add("dtls", "Details");
            data1.Columns.Add("date", "Date");
            data1.Columns.Add("lvl", "Level");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "View/Edit";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);
        }

        List<string> ID = new List<string>();
        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP()  + "/iBar/ibar_announcement.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["announcement"])
                    {
                        ID.Add(jo["id_announcement"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_announcement"]);
                        AL.Add(jo["Subject"]);
                        AL.Add(jo["Details"]);
                        AL.Add(jo["Date"]);
                        AL.Add(jo["Level"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6)
                {
                    frmAnnouncement2 frm = new frmAnnouncement2(ID[e.RowIndex].ToString());
                    frm.ShowDialog(this);

                    ID.Clear();
                    data1.Rows.Clear();
                    loadData();
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

        private void LoadCombobox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrLevel();
            cbLevel.Items.AddRange(cb.GetArrLevel().ToArray());
            cbLevel.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateToday = DateTime.Now;

                var uri = host.IP() + "/iBar/ibar_announcement_insert.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Subject"] = tbSubject.Text;
                    datas["Details"] = rbDetails.Text;
                    datas["Date"] = dtDate.Value.ToString("yyyy-MM-dd");
                    datas["Level"] = cbLevel.SelectedItem.ToString();

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
                mnpltDataGrid();
                loadData();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSubject.Text = "";
            rbDetails.Text = "";
        }
    }
}
