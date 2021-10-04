using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace testing
{
    public partial class vwrBrgyClearance : Form
    {
        public vwrBrgyClearance()
        {
            InitializeComponent();
            crystalReportViewer1.ToolPanelView = ToolPanelViewType.None;

            TextObject txtChairman, txtResidentName, txtResidentAge, txtResidentStatus, txtResidentPurpose;

            txtChairman = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strBarangayChairman"];
            txtResidentName = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentName"];
            txtResidentAge = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strAge"];
            txtResidentStatus = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentStatus"];
            txtResidentPurpose = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strResidentPurpose"];


            txtChairman.Text = "Tiago";
            txtResidentName.Text = "Noli";
            txtResidentAge.Text = "9";
            txtResidentStatus.Text = "9";
            txtResidentPurpose.Text = "9";


            TextObject txtOfficialName, txtOfficialPos1;
            txtOfficialName = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strOfficialName"];
            txtOfficialPos1 = (TextObject)rptBrgyClearance1.ReportDefinition.ReportObjects["strOfficialPos1"];
            String[] Name = { "name1", "name2", "name3" };
            String[] Position = { "Chairman1", "Chairman2", "Chairman3" };
            String[] Position2 = { "Kagawad1", "Kagawad2", "Kagawad3" };

            
            for (int i=0; i < Name.Length ;i++)
            {
                txtOfficialName.Text += Name[i].ToString() +"\n\n\n";
                txtOfficialPos1.Text += "\n"+Position[i].ToString() +"\n\n\n";

            }
        }

        private void vwrBrgyClearance_Load(object sender, EventArgs e)
        {

        }
    }
}
