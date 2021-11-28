using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testing
{
    public partial class frmBlotterRec2Update : Form
    {
        csBlotter blot = new csBlotter();
        int count;
        public frmBlotterRec2Update()
        {
            InitializeComponent();
        }

        private void frmBlotterRec2Update_Load(object sender, EventArgs e)
        {
            loadComboBox();
            retrieveData();
        }

        private void retrieveData()
        {
            blot.RetrieveData();
            tbComplainant.Text = blot.Compliant;
            tbWitness.Text = blot.Witness;
            tbRespondent.Text = blot.Respondent;
            tbLocation.Text = blot.Location;
            cbStatus.Text = blot.Status;
            cbType.Text = blot.Type;
            dtDate.Value = DateTime.ParseExact(blot.Date, "yyyy-MM-dd", CultureInfo.InvariantCulture); ;
            dtTime.Value = DateTime.ParseExact(blot.Time, "HH:mm:ss", CultureInfo.InvariantCulture); ;
            rbDetails.Text = blot.Details;

            list();
        }

        private void loadComboBox()
        {
            csComboBoxValues cb = new csComboBoxValues();
            cb.RetrieveArrBlotterStat();
            cb.RetrieveArrType();

            cbStatus.Items.AddRange(cb.GetArrBlotterStat().ToArray());
            cbType.Items.AddRange(cb.GetArrType().ToArray());

            cbStatus.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
        }


        private void btnAddAssailant_Click(object sender, EventArgs e)
        {
            frmBlotterRec3Update frm = new frmBlotterRec3Update();
            frm.ShowDialog(this);

            list();
        }

        private void list()
        {
            data1.DataSource = blot.GetArrAssailant2().Select(o => new AssailantRes2() { name = o.name }).ToList();

            data1.Columns[0].Visible = false;
            data1.Columns[1].Visible = false;
            data1.Columns[2].Visible = false;
            data1.Columns[3].HeaderText = "Name";

            data1.AutoResizeColumns();
            data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            blot.Compliant = tbComplainant.Text;
            blot.Respondent = tbRespondent.Text;
            blot.Date = dtDate.Value.ToString("yyyy-MM-dd");
            blot.Time = dtTime.Value.ToString("HH:mm");
            blot.Witness = tbWitness.Text;
            blot.Location = tbLocation.Text;
            blot.Status = cbStatus.SelectedItem.ToString();
            blot.Type = cbType.SelectedItem.ToString();
            blot.Details = rbDetails.Text;


            blot.UpdateData();
            MessageBox.Show(blot.Message);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBlotterRec2Update_FormClosing(object sender, FormClosingEventArgs e)
        {
            blot.Reset();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbStatus.SelectedItem.ToString() == "Scheduled" && count >= 2)
            {
                using (frmAppoint_insert frm = new frmAppoint_insert("Blotter"))
                {
                    frm.ShowDialog();

                    string result = frm.GetMyResult;

                    if (result != "Added")
                    {
                        MessageBox.Show("Unable to set Schedule.");
                        cbStatus.SelectedIndex = 0;
                    }
                }
            }
        }

        private void cbStatus_MouseClick(object sender, MouseEventArgs e)
        {
            count++;
        }
    }
}
