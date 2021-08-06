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
    public partial class frmRequest2 : Form
    {
        csRequest cs = new csRequest();

        public frmRequest2()
        {
            InitializeComponent();
        }

        private void frmRequest2_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadComboBoxes();
        }

        private void LoadData()
        {
            cs.retrieveData();
            lblDocument.Text = cs.Docs;
            lblDate.Text = cs.Date;
            rbPurpose.Text = cs.Purpose;
            lblCurrentStatus.Text = cs.CurrentStatus;
            lblDeliveryOption.Text = cs.DeliveryOption;
        }

        private void LoadComboBoxes()
        {
            csComboBoxValues cbValues = new csComboBoxValues();
            cbValues.RetrieveStatus();

            cbStatus.Items.AddRange(cbValues.GetArrStatus().ToArray());
            cbStatus.SelectedIndex = 0;
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            cs.ResetData();
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            cs.UpdatedStatus = cbStatus.SelectedItem.ToString();
            cs.updateData();
            MessageBox.Show(cs.Message);
        }
    }
}
