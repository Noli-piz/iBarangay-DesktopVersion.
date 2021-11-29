using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
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
            Execute();
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

            msg.AddTo(new EmailAddress("thisismenoli11@gmail.com", "Test-user"));
            var response = await client.SendEmailAsync(msg);
            MessageBox.Show(response.IsSuccessStatusCode.ToString());
        }

        static async Task Execute()
        {
            csApiKey ApiKey = new csApiKey();
            ApiKey.loadKeys();

            var apiKey = Environment.GetEnvironmentVariable("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");
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(ApiKey.getSendGridEmail(), "Example User");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress("nolipizarro11.np@gmail.com", "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            MessageBox.Show(response.IsSuccessStatusCode.ToString());

        }

        private async void MailGun()
        {
            //var client = new RestSharp.RestClient("https://api.mailgun.net/v3");
            //client.Authenticator = new RestSharp.HttpBasicAuthenticator("api", "{APIKEY}");

            //RestSharp.IRestRequest request = new RestSharp.RestRequest("/{DOMAIN}/messages", RestSharp.Method.POST);

            //string MailBody = "<html>This is test HTML & rest of message</html>";

            //request.AddParameter("from", "{EmailAddress}");
            //request.AddParameter("h:Reply-To", "{EmailAddress}");
            //request.AddParameter("to", "{EmailAddress}");
            //request.AddParameter("subject", "Mailgun Test New");

            //request.AddParameter("html", MailBody);

            //try
            //{
            //    RestSharp.IRestResponse response = client.Execute(request);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }

        private async void MailGun2()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    var authToken = Encoding.ASCII.GetBytes($"api:{_emailSettings.Value.ApiKey}");
            //    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
            //    var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
            //         { "from", $"{_emailSettings.Value.DisplayName} <{_emailSettings.Value.From}>" },
            //         { "h:Reply-To", $"{_emailSettings.Value.DisplayName} <{_emailSettings.Value.ReplyTo}>" },
            //         { "to", email },
            //         { "subject", subject },
            //         { "text", txtMessage },
            //         { "html", htmlMessage }
            //    });
            //    var result = await httpClient.PostAsync($"https://api.mailgun.net/v3/{_emailSettings.Value.EmailDomain}/messages", formContent);
            //    result.EnsureSuccessStatusCode();
            //}
        }
    }
}
