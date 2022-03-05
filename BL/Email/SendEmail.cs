using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TransportationERP.BL.Email
{
    public class SendEmail
    {
        public bool ForgotPasswordEmail(string sendToEmail, string callbackUrl)
        {
            bool res = false;
            try
            {
                if (sendToEmail != "")
                {

                    string senderMail = "noreply@gmail.com";
                    string senderPass = "@Test@123";
                    string MailHostServer = "smtp.gmail.com";
                    string port = "587";
                    string displayName = "MMS Suplier Security Management Team";

                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(senderMail, displayName);
                    string mailTo = sendToEmail;
                    mail.To.Add(mailTo);

                    mail.Subject = "Password Recovery Email";

                    mail.IsBodyHtml = true;

                    mail.Body += "<b>Dear </b><span> " + "Sir" + "</span><br/><br/>";

                    mail.Body += "Your password recovery email recieved.this is your password recovery link<br/><br/>";
                    mail.Body += "<a href='"+ callbackUrl + "'>" + callbackUrl + "</a><br/><br/>";
                    mail.Body += "Thank You for contacting us <br/><br/>";


                    mail.Priority = MailPriority.Normal;

                    var stmp = new SmtpClient();
                    stmp.Credentials = new NetworkCredential(senderMail, senderPass);
                    stmp.Host = MailHostServer;
                    stmp.Port = Convert.ToInt32(port);
                    stmp.EnableSsl = true;
                    stmp.Send(mail);
                    res = true;
                }

            }
            catch (Exception e)
            {

                res = false;
            }

            return res;
        }

    }
}
