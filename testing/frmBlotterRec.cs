using System;
using System.Collections;
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
    public partial class frmBlotterRec : Form
    {
        public frmBlotterRec()
        {
            InitializeComponent();
        }
        private void frmBlotterRec_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Complainant";
            dataGridView1.Columns[1].Name = "Victim";
            dataGridView1.Columns[2].Name = "Case Status";

            ArrayList list = new ArrayList();
            list.Add("Pizarro, Noli M.");
            list.Add("Malicia, Aling G.");
            list.Add("Active");
            dataGridView1.Rows.Add(list.ToArray());

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "Edit";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                MessageBox.Show("Update");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAddNewBlotter frm = new frmAddNewBlotter();
            frm.ShowDialog(this);
        }


    }
}
