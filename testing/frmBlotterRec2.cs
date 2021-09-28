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
    public partial class frmBlotterRec2 : Form
    {
        csBlotter blot = new csBlotter();

        public frmBlotterRec2()
        {
            InitializeComponent();
        }

        private void frmAddNewBlotter_Load(object sender, EventArgs e)
        {
            loadComboBox();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
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

            blot.InsertData();
            MessageBox.Show(blot.Message);
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
            frmBlotterRec3 frm = new frmBlotterRec3();
            frm.ShowDialog(this);

            list();
        }

        private void list()
        {
            data1.DataSource = blot.GetArrAssailant().Select(o => new AssailantRes() { name = o.name}).ToList();

            data1.Columns[0].Visible = false;
            data1.Columns[1].HeaderText = "Name";

            data1.AutoResizeColumns();
            data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
