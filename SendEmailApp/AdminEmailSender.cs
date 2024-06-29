using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MimeKit;

namespace SendEmailApp
{
    public class AdminEmailSender : IEmailSending
    {

        private NetworkCredential credential;
        public AdminEmailSender(NetworkCredential cred)
        {
            credential = cred;
        }

        public async Task SendAsync(IPersonal personal, string subject, string body)
        {

            string to = personal.Email!;
            string from = "admin@gmail.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.Body = body;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials  = credential;

            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }

            Console.WriteLine("Письмо отправлено");

        }
    }
}
