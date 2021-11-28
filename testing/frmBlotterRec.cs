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

    public partial class frmBlotterRec : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        private csBlotter blot = new csBlotter();
        public frmBlotterRec()
        {
            InitializeComponent();
        }
        private void frmBlotterRec_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            //RetrieveData();
            LoadData();
            fetchCount();
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("com", "Compliant");
            data1.Columns.Add("ass", "Assailant");
            data1.Columns.Add("det", "Detail");
            data1.Columns.Add("cstatus", "Case Status");
            data1.Columns.Add("date", "Date");

            //DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            //btn.HeaderText = "Action";
            //btn.Name = "btnGenerate";
            //btn.Text = "View/Edit";
            //btn.UseColumnTextForButtonValue = true;
            //data1.Columns.Add(btn);

            DataGridViewImageColumn btn = new DataGridViewImageColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Image = Properties.Resources.edit_icon;
            data1.Columns.Add(btn);

            data1.Columns["ID"].Visible = false;

        }

        private async void LoadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_blotter.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["blotter"])
                    {

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_blotter"]);
                        AL.Add(jo["Compliant"]);
                        AL.Add(jo["Assailant1"] +" "+ jo["Assailant2"]);
                        AL.Add(jo["Details"].ToString().Length > 20 ? jo["Details"].ToString().Substring(0,20) + "..." : jo["Details"]);
                        AL.Add(jo["Status"]);
                        AL.Add(jo["Date"]);
                        data1.Rows.Add(AL.ToArray());
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

        List<string> ID = new List<string>();
        private void RetrieveData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT b.id_blotter, b.Compliant, (SELECT GROUP_CONCAT(CONCAT_WS(' ',Fname,Mname,Lname,Sname)) FROM tbl_residentinfo WHERE id_resident " +
                    "IN (SELECT id_resident FROM tbl_assailantresident WHERE id_assailant_resident = b.id_assailant_resident AND Deleted =0)) AS Assailant1, " +
                    "(SELECT GROUP_CONCAT(Name,' ') FROM tbl_assailantnonresident WHERE id_assailant_nonresident = b.id_assailant_nonresident AND Deleted =0) AS Assailant2 , " +
                    " b.Details, b.Status , DATE_FORMAT(b.Date, '%Y-%m-%d') , b.Time  FROM tbl_blotterinfo AS b";

                cs.conn.Open();

                MySqlCommand cmd = new MySqlCommand(query, cs.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                ArrayList AL = new ArrayList();
                int count = 1;
                while (rdr.Read())
                {
                    ID.Add(rdr[0].ToString());

                    AL = new ArrayList();
                    AL.Add(count.ToString());
                    AL.Add(rdr[1].ToString());
                    AL.Add(rdr[2].ToString() +" "+ rdr[3].ToString());
                    AL.Add(rdr[4].ToString());
                    AL.Add(rdr[5].ToString());
                    AL.Add(rdr[6].ToString());
                    data1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();

                data1.AutoResizeColumns();
                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.ToString());
            }
        }
        
        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    DataGridViewRow row = data1.Rows[e.RowIndex];
                    String identifier = row.Cells[1].Value.ToString();

                    blot.GetID(identifier);
                    //blot.GetID(ID[e.RowIndex].ToString());

                    frmBlotterRec2Update frm = new frmBlotterRec2Update();
                    frm.ShowDialog(this);

                    data1.Rows.Clear();
                    //RetrieveData();
                    LoadData();
                    fetchCount();
                }
            }
            catch(ArgumentOutOfRangeException ex)
            {
                
            }
        }

        private void btn_AddBlotter_Click(object sender, EventArgs e)
        {
            frmBlotterRec2Insert frm = new frmBlotterRec2Insert();
            frm.ShowDialog(this);

            data1.Rows.Clear();
            LoadData();
        }

        private void btnActive_Click(object sender, EventArgs e)
        {
        }

        private async void fetchCount()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_blotter_count.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["count"])
                    {
                        lblActiveCases.Text = jo["Active"].ToString();
                        lblSettledCases.Text = jo["Settled"].ToString();
                        lblScheduledCases.Text = jo["Scheduled"].ToString();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cbCategory.SelectedItem) != "") {
                    data1.Rows.Clear();
                    var uri = host.IP() + "/iBar/ibar_blotter_search.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = tbSearch.Text;
                        datas["Category"] = cbCategory.SelectedItem.ToString();

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    ArrayList AL = new ArrayList();
                    var data = JsonConvert.DeserializeObject(responseFromServer);
                    string success = JObject.Parse(responseFromServer)["success"].ToString();
                    if (success == "1")
                    {
                        int i = 1;
                        foreach (var jo in (JArray)((JObject)data)["blotter"])
                        {

                            AL = new ArrayList();
                            AL.Add(i.ToString());
                            AL.Add(jo["id_blotter"]);
                            AL.Add(jo["Compliant"]);
                            AL.Add(jo["Assailant1"] + " " + jo["Assailant2"]);
                            AL.Add(jo["Details"]);
                            AL.Add(jo["Status"]);
                            AL.Add(jo["Date"]);
                            data1.Rows.Add(AL.ToArray());
                            i++;
                        }
                    }
                    else if (success == "0")
                    {
                        MessageBox.Show(JObject.Parse(responseFromServer)["message"].ToString());
                        LoadData();
                    }

                    data1.AutoResizeColumns();
                    data1.AutoResizeRows();

                    data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    data1.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Category Selected.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Connect to the Internet!" + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
        }
    }
}
