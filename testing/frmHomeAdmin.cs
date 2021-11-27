using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace testing
{
    public partial class frmHomeAdmin : Form
    {
        public frmHomeAdmin()
        {
            InitializeComponent();
        }

        private void frmHomeAdmin_Load(object sender, EventArgs e)
        {
            SendEmailAsync();
        }

        public async Task SendEmailAsync()
        {
            csApiKey ApiKey = new csApiKey();
            ApiKey.loadKeys();

            var client = new SendGridClient(ApiKey.getSendGridKey());
            var msg = new SendGridMessage()
            {

                From = new EmailAddress(ApiKey.getSendGridEmail(), "iBarangay"),
                Subject = "Sending with SendGrid is Fun",
                PlainTextContent = "COntext",
                HtmlContent = "<strong>aHtml Content</strong>"
            };

            msg.AddTo( new EmailAddress("thisismenoli11@gmail.com", "Test-user"));
            var response = await client.SendEmailAsync(msg);
            MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }
    }
}
