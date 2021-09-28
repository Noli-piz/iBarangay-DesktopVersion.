using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csRand
    {

        ///Download
        private async void DownloadImage()
        {
            var webClient = new System.Net.WebClient();
            var storage = new FirebaseStorage("ibarangay-23725.appspot.com")
                .Child("systemicon")
                .Child("Normal.png")
                .GetDownloadUrlAsync();

            var url = await storage;
            DisplayImage(url);
        }

        private async void DisplayImage(String url)
        {
            var webClient = new System.Net.WebClient();
            var bytes = webClient.DownloadData(url);
            using (var ms = new MemoryStream(bytes, 0, bytes.Length))
            {
                ms.Write(bytes, 0, bytes.Length);
                var image = System.Drawing.Image.FromStream(ms, true);
                //pictureBox1.Image = image;
                ms.Dispose();
            }
        }

        private void Fetchdatainawebsite()
        {
            //System.Net.WebClient wc = new System.Net.WebClient();
            //byte[] raw = wc.DownloadData("http://www.yoursite.com/resource/file.htm");

            //string webData = System.Text.Encoding.UTF8.GetString(raw);

            ////OR
            //System.Net.WebClient wc = new System.Net.WebClient();
            //string webData = wc.DownloadString("http://www.yoursite.com/resource/file.htm");

            //// OR

            //using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream(), Encoding.UTF8))
            //{
            //    streamWriter.Write(requestData);
            //}

            //string responseData = string.Empty;
            //HttpWebResponse httpResponse = (HttpWebResponse)webRequest.GetResponse();
            //using (StreamReader responseReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    responseData = responseReader.ReadToEnd();
            //}

        }

        private void d()
        {
            String s = "SELECT b.Compliant, " +
                "(SELECT GROUP_CONCAT(Fname,\" \",Mname,\" \",Lname,\" \",Sname) FROM tbl_residentinfo WHERE id_resident IN " +
                "(SELECT id_resident FROM tbl_assailantresident WHERE id_assailant_resident = b.id_assailant_resident)) AS Assailant1, " +
                "(SELECT GROUP_CONCAT(Name) FROM tbl_assailantnonresident WHERE id_assailant_nonresident = b.id_assailant_nonresident) AS Assailant2 , " +
                "b.Witness , b.Respondent , b.Details , b.Date , b.Time , b.Status " +
                "FROM tbl_blotterinfo AS b WHERE id_blotter = 1";

           // SELECT b.Compliant (SELECT GROUP_CONCAT(Fname,\" \",Mname,\" \",Lname,\" \",Sname) FROM tbl_residentinfo WHERE id_resident IN (SELECT id_resident FROM tbl_assailantresident WHERE id_assailant_resident = b.id_assailant_resident)) AS Assailant1, (SELECT GROUP_CONCAT(Name) FROM tbl_assailantnonresident WHERE id_assailant_nonresident = b.id_assailant_nonresident) AS Assailant2 , b.Witness , b.Respondent , b.Details , b.Date , b.Time , b.Status FROM tbl_blotterinfo AS b WHERE id_blotter = 1
        }

        private void StoredProcedure()
        {
            //cs.command = new MySqlCommand();
            //cs.command.CommandText = "RetrieveDataFromBlotterToUpdate"; //Name of the StoredeProcedure
            //cs.command.CommandType = CommandType.StoredProcedure;
            //cs.command.Parameters.AddWithValue("$id", 11); //$id is an identifier
            //cs.command.Parameters["$id"].Direction = ParameterDirection.Input;

        }

/*        private void btnClearance(object sender, EventArgs e)
        {
            ClearPanel();

            Label lblclearance = new Label();
            lblclearance.Text = "Clearance";
            lblclearance.AutoSize = true;
            lblclearance.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            lblclearance.Location = new System.Drawing.Point(10, 10);
            lblclearance.Click += new EventHandler(btnClearance);
            panel1.Controls.Add(lblclearance);

            Label lblindigency = new Label();
            lblindigency.Text = "Indigency";
            lblindigency.AutoSize = true;
            lblindigency.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            lblindigency.Click += new EventHandler(btnIndigency);
            lblindigency.Location = new System.Drawing.Point(180, 10);
            panel1.Controls.Add(lblindigency);


            frmIssueBrgyClearance frm = new frmIssueBrgyClearance() { Location = new System.Drawing.Point(0, 40), TopLevel = false, TopMost = false };
            this.panel1.Controls.Add(frm);
            frm.Show();

        }
        private void btnIndigency(object sender, EventArgs e)
        {
            ClearPanel();

            Label lblclearance = new Label();
            lblclearance.Text = "Clearance";
            lblclearance.AutoSize = true;
            lblclearance.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Regular);
            lblclearance.Location = new System.Drawing.Point(10, 10);
            lblclearance.Click += new EventHandler(btnClearance);
            panel1.Controls.Add(lblclearance);

            Label lblindigency = new Label();
            lblindigency.Text = "Indigency";
            lblindigency.AutoSize = true;
            lblindigency.Font = new Font("Microsoft Sans Serif", 20, FontStyle.Bold);
            lblindigency.Click += new EventHandler(btnIndigency);
            lblindigency.Location = new System.Drawing.Point(180, 10);
            panel1.Controls.Add(lblindigency);

            frmIssueBrgyIndigency frm = new frmIssueBrgyIndigency() { Location = new System.Drawing.Point(0, 40), TopLevel = false, TopMost = false };
            this.panel1.Controls.Add(frm);
            frm.Show();
        }*/
    }
}
