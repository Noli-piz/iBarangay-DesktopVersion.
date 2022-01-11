using MaterialSkin.Controls;
using MetroFramework.Controls;
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
    public partial class frmMessageTemplates : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        public string GetMyMessage = "";

        public frmMessageTemplates()
        {
            InitializeComponent();
        }

        private void frmMessageTemplates_Load(object sender, EventArgs e)
        {
            //frmMessageTemplate frm = new frmMessageTemplate();
            //frm.TopLevel = false;

            //panel1.Controls.Add(frm);
            //frm.Show();

            loadData();
        }

        List<string> listMessageTemplate = new List<string>();
        private async void loadData()
        {
            try
            {
                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_messagetemplate.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();
                if (success == "1")
                {
                    int count = 0;
                    foreach (var jo in (JArray)((JObject)data)["template"])
                    {
                        string id = jo["id_messagetemplate"].ToString();
                        string Subject = jo["SubjectTemplate"].ToString();
                        string Message = jo["MessageTemplate"].ToString();


                        listMessageTemplate.Insert(count, Message);
                        //listMessageTemplate.Insert(Int32.Parse(id), Message);

                        TableLayoutPanel p = new TableLayoutPanel();
                        p.ColumnCount = 1;
                        p.Height = 300;
                        p.Width = 520;
                        p.Visible = true;

                        Label l = new Label();
                        l.Text = Message;
                        l.Visible = true;
                        l.Font = new Font("Arial", 12, FontStyle.Regular);
                        l.AutoSize = false;
                        l.MinimumSize = new Size(490, 290);
                        l.Padding = new Padding(10);

                        MaterialCard card = new MaterialCard();
                        card.Height = 200;
                        card.Width = 500;

                        FlowLayoutPanel flow = new FlowLayoutPanel();
                        flow.Width = 500;
                        flow.Margin = new Padding(20,0,0,0);

                        MetroButton btnSelect = new MetroButton();
                        btnSelect.Text = "Select";
                        btnSelect.Tag = count;
                        btnSelect.Name = id;
                        btnSelect.Height = 40;
                        btnSelect.Width = 100;
                        btnSelect.Visible = true;
                        btnSelect.Click += new EventHandler(btnSelect_Click);

                        MetroButton btnDelete= new MetroButton();
                        btnDelete.Text = "Delete";
                        btnDelete.Tag = count;
                        btnDelete.Name = id;
                        btnDelete.Height = 40;
                        btnDelete.Width = 100;
                        btnDelete.Visible = true;
                        btnDelete.Click += new EventHandler(btnDelete_Click);

                        flow.Controls.Add(btnDelete);
                        flow.Controls.Add(btnSelect);
                        card.Controls.Add(l);
                        p.Controls.Add(card);
                        p.Controls.Add(flow);
                        flowLayoutPanel1.Controls.Add(p);

                        count++;
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

        private void btnAddd_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbMessage.Text != "" && rbMessage.Text != null)
                {

                    var uri = host.IP() + "/iBar/ibar_messagetemplate_insert.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["SubjectTemplate"] = "Something";
                        datas["MessageTemplate"] = rbMessage.Text;


                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Insert Successfully");
                        rbMessage.Text = "";

                        flowLayoutPanel1.Controls.Clear();
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed: " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill-up all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            string id = (sender as Button).Tag.ToString();
            string message = listMessageTemplate[Int32.Parse(id)];
            GetMyMessage = message;
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbMessage.Text != "" && rbMessage.Text != null)
                {

                    var uri = host.IP() + "/iBar/ibar_messagetemplate_update.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = "1";
                        datas["SubjectTemplate"] = "Something";
                        datas["MessageTemplate"] = rbMessage.Text;


                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Update Successfully");
                        rbMessage.Text = "";

                        flowLayoutPanel1.Controls.Clear();
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Insert Failed: " + responseFromServer);
                    }
                }
                else
                {
                    MessageBox.Show("Please fill-up all fields.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wan to delete?", "Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string id = (sender as Button).Name.ToString();
                    var uri = host.IP() + "/iBar/ibar_messagetemplate_delete.php";

                    string responseFromServer;
                    using (var wb = new WebClient())
                    {
                        var datas = new NameValueCollection();
                        datas["ID"] = id;

                        var response = wb.UploadValues(uri, "POST", datas);
                        responseFromServer = Encoding.UTF8.GetString(response);
                    }

                    if (responseFromServer == "Operation Success")
                    {
                        MessageBox.Show("Delete Successfully");
                        rbMessage.Text = "";

                        flowLayoutPanel1.Controls.Clear();
                        loadData();

                    }
                    else
                    {
                        MessageBox.Show("Insert Failed: " + responseFromServer);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
