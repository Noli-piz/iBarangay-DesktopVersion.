using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Syncfusion.Windows.Forms.Schedule;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsCalendar;

namespace testing
{
    public partial class frmTesting : Form
    {
        private List<CalendarItem> _items = new List<CalendarItem>();
        csHostConfiguration host = new csHostConfiguration();
        public frmTesting()
        {
            InitializeComponent();
        }

        private void frmTesting_Load(object sender, EventArgs e)
        {
            DateTime newDate = DateTime.Now;
            CalendarItem item = new CalendarItem(calendar1, DateTime.Now.AddHours(-4), newDate, "TEST");
            _items.Add(item);
            LoadData();
        }

        private async void LoadData()
        {
            try
            {

                HttpClient client = new HttpClient();
                var uri = host.IP() + "/iBar/ibar_appointment.php";
                string responseBody = await client.GetStringAsync(uri);

                var data = JsonConvert.DeserializeObject(responseBody);
                string success = JObject.Parse(responseBody)["success"].ToString();

                List<int> colorInt = new List<int>();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["appointment"])
                    {
                        //AL.Add(jo["id_appointment"]);
                        //AL.Add(jo["Title"]);
                        //AL.Add(jo["Name"]);
                        //AL.Add(jo["Details"]);
                        //AL.Add(jo["Date"]);
                        //AL.Add(jo["StartTime"]);
                        //AL.Add(jo["EndTime"]);

                        String info = "Title: " + jo["Title"] + "\n" +
                                       "Name: " + jo["Name"] + "\n" +
                                       "Details: " + jo["Details"];

                        DateTime dte1 = DateTime.ParseExact(jo["StartTime"].ToString(), "yyyy-MM-dd HH:mm tt", null);
                        DateTime dte2 = DateTime.ParseExact(jo["EndTime"].ToString(), "yyyy-MM-dd HH:mm tt", null);


                        CalendarItem item = new CalendarItem(calendar1, dte1, dte2, info);
                        _items.Add(item);

                    }

                }
                else if (success == "0")
                {
                    MessageBox.Show(JObject.Parse(responseBody)["message"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            foreach (CalendarItem calendarItem in _items)
            {
                if (this.calendar1.ViewIntersects(calendarItem))
                {
                    this.calendar1.Items.Add(calendarItem);
                }
            }
        }

        private void monthView1_SelectionChanged(object sender, EventArgs e)
        {
            calendar1.SetViewRange(monthView1.SelectionStart.Date, monthView1.SelectionEnd.Date);
        }

        private void calendar1_Click(object sender, EventArgs e)
        {

            //MessageBox.Show("Putang");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAppoint_insert frm = new frmAppoint_insert();
            frm.ShowDialog(this);
        }
    }
}
