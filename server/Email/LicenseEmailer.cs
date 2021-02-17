//using Dapper;
//using Microsoft.Data.SqlClient;
//using Models.System.DTO.Query;
//using SendGrid;
//using SendGrid.Helpers.Mail;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;


//namespace Email
//{
//    public class LicenseEmailer
//    {
//        public void Run(DataAccess.Context.LicensingDbContext db, string connectionString)
//        {
//            //var emailSettings = db.EmailSettings.FirstOrDefault();
//            int checkMonths = 3;




//            using (SqlConnection connection = new SqlConnection(connectionString))
//            {
//                var expiringLicenses = connection.Query<LicenseDTO>(@$"SELECT L.ID, L.SiteID, L.ProductID, L.AdminUserID, L.ExpiryDate, L.Notes, S.SiteName AS SiteName, P.ProductName AS ProductName, AU.FirstName + ' ' + AU.LastName AS AdminUserName
//                                                                    FROM License AS L

 

//                                                                    INNER JOIN
//                                                                    Site AS S
//                                                                    ON L.SiteID = S.ID

 

//                                                                    INNER JOIN
//                                                                    Product AS P
//                                                                    ON L.ProductID = P.ID

 

//                                                                    INNER JOIN
//                                                                    AdminUser AS AU
//                                                                    ON L.AdminUserID = AU.ID 
//                                                                    WHERE L.ExpiryDate <= DATEADD(month, {checkMonths}, GETDATE())").ToList();



//                if (expiringLicenses != null && expiringLicenses.Count > 0)
//                {



//                    //get customers
//                    var adminUserList = db.AdminUser.ToList();



//                    SendEmail(adminUserList, expiringLicenses).Wait();
//                }
//            }
//        }





//        public async Task<bool> SendEmail(List<Models.System.AdminUser> lsPeopleToSendTo, List<Models.System.DTO.LicenseDTO> lsLicences)
//        {
//            string apiKey = "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";
//            string templateID = "d-8b90f39bf2054422b3c94935f1eabc6a";
//            var client = new SendGridClient(apiKey);
//            var from = new EmailAddress("licensing@devinspire.co.za", "Licensing Server Notifier");



//            List<EmailAddress> recipients = new List<EmailAddress>();



//            foreach (var person in lsPeopleToSendTo)
//            {
//                recipients.Add(new EmailAddress(person.EmailAddress));
//            }



//            // POPULATE DATA



//            EmailData_Renewals data = new EmailData_Renewals();
//            data.user_full_name = "X";
//            data.renewal_list = new List<Email_Data_Renewal_Customer>();



//            DateTime dt = DateTime.Now;
//            TimeSpan ts = new TimeSpan();

//            foreach (var license in lsLicences)
//            {
//                //ts = dt - license.expirydate;
//                //string expiresin = $"days: {ts.days}";
//                //data.renewal_list.add(new email_data_renewal_customer { customer = "customer - (license.customername) " + license.sitename, expiresin = expiresin, open_link = "www.google.co.za", product = license.productname });

//                data.renewal_list.Add(new Email_Data_Renewal_Customer { customer = license.CustomerName + " for site: " + license.SiteName, expiresIn = expiresIn, open_link = "www.google.co.za", product = license.ProductName });
//            }



//            var msg = MailHelper.CreateSingleTemplateEmailToMultipleRecipients(from, recipients, templateID, data);



//            var response = await client.SendEmailAsync(msg);



//            //getAlluserEmails
//            List<EmailAddress> tos = new List<EmailAddress>
//                {
//                    new EmailAddress("erwin@devinpire.co.za", "Example User 2"),
//                    new EmailAddress("test3@example.com", "Example User 3")
//                };





//            if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted) // MEANS THAT 200 OK was recieved
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }



//        }
//    }
//}
