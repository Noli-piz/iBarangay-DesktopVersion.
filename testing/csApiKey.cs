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
            sendgridKey = "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";
            sendgridEmail = "sti_ibarangay@outlook.com";
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
