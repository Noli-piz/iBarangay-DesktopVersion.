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
        private static string id, Username, Name, LevelOfAccess;

        public csUser()
        {
        }

        public void usercredentials(String uname, String password)
        {
            getUser(uname, password);
        }

        private async void getUser(String uname, String password)
        {
            try
            {
                var uri = host.IP() + "/iBar/ibar_login_getuser.php";

                string responseFromServer;
                using (var wb = new WebClient())
                {
                    var datas = new NameValueCollection();
                    datas["Username"] = uname;
                    datas["Password"] = password;

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
                        LevelOfAccess = jo["LevelOfAccess"].ToString();
                        Message = JObject.Parse(responseFromServer)["message"].ToString();
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
        public string strID() { return id; }
        public string username() { return Username; }
        public string name()  { return Name; }
        public string getLevelOfAccess()  { return LevelOfAccess; }
    }
}
