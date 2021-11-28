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
using MetroFramework.Controls;
using MySql.Data.MySqlClient;

namespace testing
{
    public partial class frmBlotterRec3Insert : Form
    {
        private csConnection cs = new csConnection();
        private csBlotter blot = new csBlotter();
        private ArrayList arraySuggest;

        public frmBlotterRec3Insert()
        {
            InitializeComponent();
        }

        private void frmBlotterRec3_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData("");
            SelectedAssailant();
        }

        private void tbSearch1_TextChanged(object sender, EventArgs e)
        {
            String query, text = tbSearch1.Text.Trim();
            query = " WHERE CONCAT_WS(' ', Fname, Mname, Lname) LIKE '%" + text + "%'";
            data1.Rows.Clear();
            loadData(query);
        }

        private void mnpltDataGrid()
        {
            ID.Clear();
            data1.Rows.Clear();
            data1.Columns.Clear();
            data1.Visible = false;

            data1.Columns.Add("no", "No.");
            data1.Columns.Add("flname", "Fullname");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "Action";
            btn.Name = "btnGenerate";
            btn.Text = "Add";
            btn.UseColumnTextForButtonValue = true;
            data1.Columns.Add(btn);


        }

        List<string> ID = new List<string>();
        private void loadData(String q)
        {
            try
            {
                csConnection cs = new csConnection();
                String query = "SELECT id_resident, Fname,Mname, Lname, Sname FROM tbl_residentinfo "+q;

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
                    AL.Add(rdr[1].ToString() +" "+ rdr[2].ToString() +" "+rdr[3].ToString() +" "+rdr[4].ToString());
                    data1.Rows.Add(AL.ToArray());
                    count++;
                }
                rdr.Close();
                cmd.Dispose();
                cs.conn.Close();


                data1.AutoResizeColumns();
                data1.AutoResizeRows();

                data1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                data1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                data1.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnGenerate_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 2)
                {
                    String fname = data1.Rows[e.RowIndex].Cells[1].Value.ToString(); 
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to add " + fname + "?", "Add", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        AssailantRes assres = new AssailantRes();
                        assres.id = Int32.Parse(ID[e.RowIndex].ToString());
                        assres.name = fname;

                        bool exist = false;
                        foreach (var str in blot.GetArrAssailant())
                        {
                            if (str.id == assres.id && str.name == assres.name)
                            {
                                MessageBox.Show("This Person is already Exist!");
                                exist = true;
                                break;
                            }
                        }

                        if (exist == false)
                        {
                            blot.AddAssailant(assres);
                            SelectedAssailant();

                        }

                        // Temporary Store
                        TemporaryAssailant tempAss = new TemporaryAssailant();
                        tempAss.id = Int32.Parse(ID[e.RowIndex].ToString());
                        tempAss.name = fname;

                        TempBlot temp = new TempBlot();
                        temp.AddTempAssailant(tempAss);
                    }
                }
            }
            catch (ArgumentOutOfRangeException outOfRange)
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnOkay_Click(object sender, EventArgs e)
        {
            TempBlot tempAss = new TempBlot();
            tempAss.RemoveTempAssailant();
            this.Close();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            AssailantRes assres = new AssailantRes();
            assres.id = 0;
            assres.name = tbEnterName.Text;

            bool exist = false;
            foreach (var str in blot.GetArrAssailant())
            {
                if (str.id == assres.id && str.name == assres.name)
                {
                    MessageBox.Show("This Person is already Exist!");
                    exist = true;
                    break;
                }
            }

            if (exist == false) {
                blot.AddAssailant(assres);
                SelectedAssailant();

                TemporaryAssailant tempAss = new TemporaryAssailant();
                tempAss.from = "insertnonresident";
                tempAss.id = 0;
                tempAss.name = tbEnterName.Text;

                TempBlot temp = new TempBlot();
                temp.AddTempAssailant(tempAss);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Button btnRem = (Button)sender;
            int strID = Int32.Parse(btnRem.Tag.ToString());
            String strName = btnRem.Name;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove "+strName+"?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                blot.RemoveAssailant(new AssailantRes() { id = strID, name = strName });
                SelectedAssailant();
            }
        }

        private void SelectedAssailant()
        {

            boxpanel.Controls.Clear();
            boxpanel.RowCount = blot.GetArrAssailant().Count;
            int x = 0;
            foreach (var str in blot.GetArrAssailant())
            {
                TableLayoutPanel p = new TableLayoutPanel();
                p.ColumnCount = 2;
                p.Dock = DockStyle.Fill;
                p.Height = 40;
                p.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
                p.Visible = true;

                Label l = new Label();
                l.Text = str.name.ToString();
                l.Margin = new Padding(5, 5, 5, 10);
                l.Visible = true;
                l.Font = new Font("Arial", 12, FontStyle.Regular);
                l.AutoSize = true;
                l.MaximumSize = new Size(300,40);

                MetroButton btn = new MetroButton();
                btn.Text = "Remove";
                btn.Tag = str.id.ToString();
                btn.Name = str.name.ToString();
                btn.Margin = new Padding(5, 5, 5, 10);
                btn.AutoSize = true;
                btn.Visible = true;
                btn.Click += new EventHandler(btnRemove_Click);

                p.Controls.Add(l);
                p.Controls.Add(btn);
                boxpanel.Controls.Add(p);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TempBlot tempAss = new TempBlot();

            foreach (var str in tempAss.GetTempArrAssailant())
            {
                blot.RemoveAssailant(new AssailantRes() { id = str.id, name = str.name });
            }

            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            boxpanel.Controls.Clear();
            blot.ResetAssailant();
            //this.Close();
        }


        public class TempBlot
        {

            public static List<TemporaryAssailant> temp = new List<TemporaryAssailant>();

            public void AddTempAssailant(TemporaryAssailant a)
            {
                temp.Add(a);
            }

            public void RemoveTempAssailant()
            {
                temp = new List<TemporaryAssailant>();
            }

            public List<TemporaryAssailant> GetTempArrAssailant()
            {
                return temp;
            }

        }

        public class TemporaryAssailant
        {
            public string from { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }

    }
}
