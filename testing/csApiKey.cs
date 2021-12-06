using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class csApiKey
    {

        private static string sendgridKey, sendgridEmail;

        public void loadKeys()
        {
            sendgridEmail = "sti_ibarangay@outlook.com";
        }

        public void setSendGridKey(String key)
        {
            sendgridKey = key;
        }

        public string getSendGridKey()
        {
            return sendgridKey;
        }

        public string getSendGridEmail()
        {
            return sendgridEmail;
        }
    }
}
