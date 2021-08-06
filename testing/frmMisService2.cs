using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmMisService2 : Form
    {
        csMisService ser = new csMisService();

        public frmMisService2()
        {
            InitializeComponent();
        }

        private void frmMisService2_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxes();
        }

        private void LoadData()
        {
            ser.retrieveData();
            lblItem.Text = ser.ItemName;
            lblDate.Text = ser.Date;
            rbPurpose.Text = ser.Purpose;
            lblCurrentStatus.Text = ser.Status;
            lblDeliveryOption.Text = ser.deliveryOption;
            lblQuantity.Text = ser.Quantity;
        }

        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveArrStatusService();

            cbStatus.Items.AddRange(cbValues.GetArrStatusService().ToArray());
            cbStatus.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ser.Reset();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ser.UpdatedStatus = cbStatus.SelectedItem.ToString();
            ser.UpdatedDeadline = dtDeadline.Value.Date.ToString("yyyy-mm-dd");
            if (cbStatus.SelectedItem.ToString() == "Approved")
            {
                ser.updateData2();
            }
            else if(cbStatus.SelectedItem.ToString() == "Returned")
            {
                ser.updateData();
            }
            else
            {
                ser.updateData3();
            }
            MessageBox.Show(ser.Message);
        }
    }
}
