using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace testing
{

    class csUser
    {
        csHostConfiguration host = new csHostConfiguration();
        private static string id, Username, Name;

        public csUser()
        {
        }

        public void usercredentials(String uname)
        {
            getUser(uname);
        }

        private async void getUser(String uname)
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_login_getuser.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Username"] = uname;

                    var response = wb.UploadValues(uri, "POST", datas);
                    responseFromServer = Encoding.UTF8.GetString(response);
                }


                var data = JsonConvert.DeserializeObject(responseFromServer);
                string success = JObject.Parse(responseFromServer)["success"].ToString();
                if (success == "1")
                {
                    foreach (var jo in (JArray)((JObject)data)["userlogin"])
                    {
                        id = jo["id_users"].ToString();
                        Username = jo["Username"].ToString();
                        Name = jo["Fullname"].ToString();
                    }
                }
                else if (success == "0")
                {
                    Message = JObject.Parse(responseFromServer)["message"].ToString();
                }


            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public string Message { get; private set; }
        public string username() { return Username; }
        public string name()  { return Name; }
    }
}
