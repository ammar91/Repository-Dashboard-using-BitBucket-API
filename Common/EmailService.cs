using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class EmailService
    {
        public static void NotifyOnIssueCreate(string issueTitle)
        {
            var destination = ConfigurationManager.AppSettings["EmailNotifications"];
            var smtpSection = ConfigurationManager.GetSection("system.net/mailSettings/smtp") as SmtpSection;

            if (smtpSection != null)
            {
                var body = string.Format("New Issue has been created <b>'{0}'</b>", issueTitle);
                var mailMessage = new MailMessage(smtpSection.Network.UserName, destination, "New Issue Created", body);

                mailMessage.IsBodyHtml = true;

                using (var client = new SmtpClient())
                {
                    client.Send(mailMessage);
                }
            }
        }
    }
}
