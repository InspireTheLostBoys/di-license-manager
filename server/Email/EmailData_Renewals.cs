using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Email
{
    /**
 * {
"user_full_name": "Jason Werber",
"renewal_list": [{"customer":"DevInspire PTY LTD", "product":"Incenti-5", "expiresIn": "30 days", "open_link":"https://devinspire.co.za"}]
}
 */
    public class EmailData_Renewals
    {
        public string user_full_name { get; set; }
        public List<Email_Data_Renewal_Customer> renewal_list { get; set; }
    }



    public class Email_Data_Renewal_Customer
    {
        public string customer { get; set; }
        public string product { get; set; }
        public string expiresIn { get; set; }
        public string open_link { get; set; }
    }
}