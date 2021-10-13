using MySql.Data.MySqlClient;
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
    public partial class frmBlotterRec3Update : Form
    {
        private csConnection cs = new csConnection();
        private csBlotter blot = new csBlotter();
        


        public frmBlotterRec3Update()
        {
            InitializeComponent();
        }
        private void frmBlotterRec3Update_Load(object sender, EventArgs e)
        {
            mnpltDataGrid();
            loadData("");
            SelectedAssailant();
        }
        private void tbSearch1_TextChanged(object sender, EventArgs e)
        {
            String query, text = tbSearch1.Text.Trim();
            query = " WHERE CONCAT(Fname, Mname, Lname) LIKE '%" + text + "%'";
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
                String query = "SELECT id_resident, Fname,Mname, Lname, Sname FROM tbl_residentinfo " + q;

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
                    AL.Add(rdr[1].ToString() + " " + rdr[2].ToString() + " " + rdr[3].ToString() + " " + rdr[4].ToString());
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
                        AssailantRes2 assres2 = new AssailantRes2();
                        assres2.from = "insertresident";
                        assres2.id = Int32.Parse(ID[e.RowIndex].ToString());
                        assres2.name = fname;

                        bool exist = false;
                        foreach (var str in blot.GetArrAssailant2())
                        {

                            if (str.id == assres2.id && str.name == assres2.name && str.from == assres2.from)
                            {


                                Console.WriteLine("====================================== IF ======================== ");
                                Console.WriteLine(str.id + " = " + assres2.id);
                                Console.WriteLine(str.name + " = " + assres2.name);
                                Console.WriteLine(str.from + " = " + assres2.from);

                                MessageBox.Show("This Person is already Exist!");
                                exist = true;
                                break;

                            }
                            else if(str.idresident == assres2.id && str.name == assres2.name && "resident" == str.from)
                            {
                                Console.WriteLine( "====================================== ELSE IF ======================== ");
                                Console.WriteLine( str.idresident + " = " + assres2.id);
                                Console.WriteLine( str.name + " = " + assres2.name);
                                Console.WriteLine( str.from + " = " + "resident");

                                MessageBox.Show("This Person is already Exist!");
                                exist = true;
                                break;
                            }

                        }

                        if (exist == false)
                        {
                            blot.AddAssailant2(assres2);
                            SelectedAssailant();

                            Console.WriteLine("------ " + exist + " ---------");
                        }

                        // Temporary Store
                        TemporaryAssailant2 tempAss = new TemporaryAssailant2();
                        tempAss.from = "insertresident";
                        tempAss.id = Int32.Parse(ID[e.RowIndex].ToString());
                        tempAss.name = fname;

                        TempBlot temp = new TempBlot();
                        temp.AddTempAssailant2(tempAss);


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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            AssailantRes2 assres2 = new AssailantRes2();
            assres2.from = "insertnonresident";
            assres2.id = 0;
            assres2.name = tbEnterName.Text;

            bool exist = false;
            foreach (var str in blot.GetArrAssailant2())
            {
                if (str.id == assres2.id && str.name == assres2.name)
                {
                    MessageBox.Show("This Person is already Exist!");
                    exist = true;
                    break;
                }
            }

            if (exist == false)
            {
                blot.AddAssailant2(assres2);
                SelectedAssailant();

                TemporaryAssailant2 tempAss = new TemporaryAssailant2();
                tempAss.from = "insertnonresident";
                tempAss.id = 0;
                tempAss.name = tbEnterName.Text;

                TempBlot temp = new TempBlot();
                temp.AddTempAssailant2(tempAss);
            }
        }


        private void btnRemove_Click(object sender, EventArgs e)
        {
            Button btnRem = (Button)sender;
            int strID = Int32.Parse(btnRem.Tag.ToString());
            String strName = btnRem.Name;

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove " + strName + "?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                blot.RemoveAssailant2(new AssailantRes2() { id = strID, name = strName });
                SelectedAssailant();
            }
        }

        private void SelectedAssailant()
        {

            boxpanel.Controls.Clear();
            boxpanel.RowCount = blot.GetArrAssailant2().Count;
            int x = 0;
            foreach (var str in blot.GetArrAssailant2())
            {
                TableLayoutPanel p = new TableLayoutPanel();
                p.ColumnCount = 2;
                p.Dock = DockStyle.Fill;
                p.Height = 40;
                p.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
                p.Visible = true;

                Label l = new Label();
                l.Text = str.name.ToString();
                l.Margin = new Padding(5, 5, 5, 10);
                l.Visible = true;

                Button btn = new Button();
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

        private void btnOkay_Click(object sender, EventArgs e)
        {
            TempBlot tempAss = new TempBlot();
            tempAss.RemoveTempAssailant2();
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            TempBlot tempAss = new TempBlot();

            foreach (var str in tempAss.GetTempArrAssailant2())
            {
                blot.RemoveAssailant2(new AssailantRes2() { id = str.id, name = str.name });
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

            public static List<TemporaryAssailant2> temp = new List<TemporaryAssailant2>();

            public void AddTempAssailant2(TemporaryAssailant2 a)
            {
                temp.Add(a);
            }

            public void RemoveTempAssailant2()
            {
                temp = new List<TemporaryAssailant2>();
            }

            public List<TemporaryAssailant2> GetTempArrAssailant2()
            {
                return temp;
            }

        }

        public class TemporaryAssailant2
        {
            public string from { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }
    }


}
