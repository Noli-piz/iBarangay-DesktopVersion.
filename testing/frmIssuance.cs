using CrystalDecisions.CrystalReports.Engine;
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
using Microsoft.VisualBasic;


namespace testing
{
    public partial class frmIssuance : Form
    {
        csHostConfiguration host = new csHostConfiguration();

        public frmIssuance()
        {
            InitializeComponent();
        }

        private void frmIssuance_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            LoadData();
            //LoadOfficials();
        }

        List<string> ID = new List<string>();
        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("id", "ID.");
            data1.Columns.Add("fullname", "Full Name");
            data1.Columns.Add("age", "Age");
            data1.Columns.Add("bday", "Birthdate");
            data1.Columns.Add("gen", "Gender");
            data1.Columns.Add("vstatus", "Voter Stat.");
            data1.Columns.Add("blotter", "Blotter Case");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Documents";
            btn.Text = "Barangay Clearance";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);

            DataGridViewButtonColumn btn2 = new DataGridViewButtonColumn();
            btn2.Text = "Good Moral";
            btn2.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn2);

            DataGridViewButtonColumn btn3 = new DataGridViewButtonColumn();
            btn3.Text = "Indigency";
            btn3.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn3);
        }


        private async void LoadData()
        {

            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_issuance.php";
                string responseBody = await client.GetStringAsync(uri);

                ArrayList AL = new ArrayList();
                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int i = 1;
                    foreach (var jo in (JArray)((JObject)data)["issuance"])
                    {
                        ID.Add(jo["id_resident"].ToString());

                        AL = new ArrayList();
                        AL.Add(i.ToString());
                        AL.Add(jo["id_resident"]);
                        AL.Add(jo["Fname"] +" "+ jo["Mname"] +" "+ jo["Lname"] +" "+ jo["Sname"]);
                        AL.Add(jo["Age"]);
                        AL.Add(jo["Birthdate"]);
                        AL.Add(jo["Gender"]);
                        AL.Add(jo["VoterStatus"]);
                        AL.Add(jo["Blotter"]);
                        data1.Rows.Add(AL.ToArray());
                        i++;
                    }
                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }

                data1.Columns["ID"].Visible = false;
                data1.AutoResizeColumns();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void RLoadData()
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT id_resident, Fname, Mname, Lname, Sname, Birthdate, Gender, VoterStatus, " +
                    "(SELECT COUNT(id_assailant_resident) FROM tbl_assailantresident WHERE id_resident = res.id_resident AND Deleted = 0) AS Blotter " +
                    "FROM tbl_residentinfo AS res";

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
                    AL.Add(rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString());
                    AL.Add(rdr[5].ToString());
                    AL.Add(rdr[6].ToString());
                    AL.Add(rdr[7].ToString());
                    AL.Add(rdr[8].ToString());
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
                DataGridViewRow row = data1.Rows[e.RowIndex];
                String identifier = row.Cells[1].Value.ToString();

                if (e.ColumnIndex == 8)
                {

                    string inputPurpose = "";
                    DialogResult dialogResult = ShowInputDialog(ref inputPurpose);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (inputPurpose == "")
                        {
                            MessageBox.Show("Please input the Purpose for Requesting of this Document.");
                        }
                        else
                        {
                            vwrBrgyClearance vwr = new vwrBrgyClearance(identifier, inputPurpose);
                            vwr.ShowDialog(this);
                        }
                    }



                }
                else if (e.ColumnIndex == 9)
                {
                    string inputPurpose = "";
                    DialogResult dialogResult = ShowInputDialog(ref inputPurpose);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (inputPurpose == "")
                        {
                            MessageBox.Show("Please input the Purpose for Requesting of this Document.");
                        }
                        else
                        {
                            vwrGoodMoral vwr = new vwrGoodMoral(identifier, inputPurpose);
                            vwr.ShowDialog(this);
                        }
                    }
                }

                else if (e.ColumnIndex == 10)
                {
                    string inputPurpose = "";
                    DialogResult dialogResult = ShowInputDialog(ref inputPurpose);
                    if (dialogResult == DialogResult.OK)
                    {
                        if (inputPurpose == "")
                        {
                            MessageBox.Show("Please input the Purpose for Requesting of this Document.");
                        }
                        else
                        {
                            vwrIndigency vwr = new vwrIndigency(identifier, inputPurpose);
                            vwr.ShowDialog(this);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cbCategory.SelectedItem) != "")
                {
                    data1.Rows.Clear();
                    var uri = host.IP() + "/iBar/ibar_issuance_search.php";

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
                        foreach (var jo in (JArray)((JObject)data)["issuance"])
                        {

                            AL = new ArrayList();
                            ID.Add(jo["id_resident"].ToString());

                            AL = new ArrayList();
                            AL.Add(i.ToString());
                            AL.Add(jo["id_resident"]);
                            AL.Add(jo["Fname"] + " " + jo["Mname"] + " " + jo["Lname"] + " " + jo["Sname"]);
                            AL.Add(jo["Age"]);
                            AL.Add(jo["Birthdate"]);
                            AL.Add(jo["Gender"]);
                            AL.Add(jo["VoterStatus"]);
                            AL.Add(jo["Blotter"]);
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

        private static DialogResult ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(300, 130);
            Form inputBox = new Form();
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Purpose";

            Label prompt = new Label();
            prompt.AutoSize = true;
            prompt.Location = new System.Drawing.Point(5, 5);
            prompt.Text = "Please enter the Purpose.";
            inputBox.Controls.Add(prompt);

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 59);
            textBox.Location = new System.Drawing.Point(5, 25);
            textBox.Font = new Font("Times New Roman", 12.0f, FontStyle.Regular);
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Multiline = true;
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 90);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 90);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSearch.Text = "";
            ID.Clear();
            data1.Rows.Clear();
            LoadData();
        }
    }
}
