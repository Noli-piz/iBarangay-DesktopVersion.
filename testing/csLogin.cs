using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace testing
{
    class csLogin
    {
        csHostConfiguration host = new csHostConfiguration();
        private string uname,pass,utype;

        public void Login(String uname, String pass, String utype)
        {
            this.uname = uname;
            this.pass = pass;
            this.utype = utype;
            Logins();
        }

        private async void Logins()
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_login.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Username"] = uname;
                    datas["Password"] = pass;
                    datas["Usertype"] = utype;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }

                Console.WriteLine(responseFromServer);

                if (responseFromServer == "Login Success")
                {

                    Message = responseFromServer;
                    uType = utype;
                }
                else
                {
                    Message = responseFromServer;
                }


            }
            catch (Exception ex)
            {
                Message = ex.Message;

            }
        }

        public void Reset()
        {
            Message = "";
        }

        public string Message{ get; private set; }
        public string uType{ get; private set; }

    }
}
