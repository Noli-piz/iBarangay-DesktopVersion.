using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmAppoint_insert : Form
    {
        csHostConfiguration host = new csHostConfiguration();
        DateTime dateStart, dateEnd;

        public frmAppoint_insert()
        {
            InitializeComponent();
        }

        public void fetchDate(DateTime dateStart, DateTime dateEnd)
        {
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;

            dtStartDate.Value = dateStart;
            dtStartTime.Value = dateStart;
            dtEndDate.Value = dateEnd;
            dtEndTime.Value = dateEnd;
        }

        private void frmAppoint_insert_Load(object sender, EventArgs e)
        {

        }

        private void dtTimeAndDate_ValueChanged(object sender, EventArgs e)
        {

            if (dtStartDate.Value > dtEndDate.Value)
            {
                dtStartDate.Value = dtEndDate.Value;
                MessageBox.Show("Unable to Perform Action");
            }
            else if (dtStartDate.Value == dtEndDate.Value)
            {
                if (dtStartTime.Value.TimeOfDay > dtEndTime.Value.TimeOfDay)
                {
                    dtStartTime.Value = dtEndTime.Value.AddHours(-1);
                    MessageBox.Show("Unable to Perform Action");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

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
                    datas["Date"] = dtStartDate.Value.ToString("yyyy-MM-dd");
                    datas["StartTime"] = dtStartDate.Value.ToString("yyyy-MM-dd ") + dtStartTime.Value.ToString("HH:mm tt");
                    datas["EndTime"] = dtEndDate.Value.ToString("yyyy-MM-dd ") + dtEndTime.Value.ToString("HH:mm tt");
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
        }
    }
}
