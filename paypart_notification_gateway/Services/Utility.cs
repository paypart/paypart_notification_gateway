using paypart_notification_gateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace paypart_notification_gateway.Services
{
    public class Utility
    {
        public async Task<bool> SendMail(EmailMetaData data)
        {
            bool isSent = false; 
            MailMessage mail = new MailMessage();
            mail.To.Add(data.toaddress);
            mail.From = new MailAddress(data.fromaddress);
            mail.Subject = data.subject;
            string Body = data.body;
            mail.Body = Body;
            mail.IsBodyHtml = data.isHtml;

            Console.Write(mail.To.ToList().FirstOrDefault());

            SmtpClient smtp = new SmtpClient();
            smtp.Host = data.protocol.host;
            smtp.Port = data.protocol.port;
            smtp.EnableSsl = data.protocol.enablessl;
            smtp.Credentials = new NetworkCredential(mail.From.Address, "Paypart22$");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                //smtp.Send(mail);
                await smtp.SendMailAsync(mail);
                isSent = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
            return isSent;
        }
    }
}
