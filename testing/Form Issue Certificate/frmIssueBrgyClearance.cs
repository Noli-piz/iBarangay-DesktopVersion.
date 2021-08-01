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

namespace testing.Form_Issue_Certificate
{
    public partial class frmIssueBrgyClearance : Form
    {
        public frmIssueBrgyClearance()
        {
            InitializeComponent();
        }

        private void frmIssueBrgyClearance_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Address";
            dataGridView1.Columns[2].Name = "Voter Status";
            
            ArrayList list = new ArrayList();
            list.Add("Pizarro, Noli M.");
            list.Add("Santiago Street");
            list.Add("No");
            dataGridView1.Rows.Add(list.ToArray());

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "Generate";
            btn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(btn);

        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                vwrBrgyClearance vwr = new vwrBrgyClearance();
                vwr.ShowDialog(this);
            }
        }
    }
}
