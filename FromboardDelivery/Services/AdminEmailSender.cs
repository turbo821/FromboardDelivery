﻿using FromboardDelivery.Interfaces;
using System.Net;
using System.Net.Mail;

namespace FromboardDelivery.Services
{
    public class AdminEmailSender : IEmailSending
    {
        public string FromEmail { get; set; } = "admin@gmail.com";
        public string FromName { get; set; } = "Tom";
        public string ToEmail { get; set; } = "customer3432@gmail.com";
        public string EmailClient { get; set; } = "smtp.gmail.com";
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
            client.Credentials = credential;
            try
            {
                await client.SendMailAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }
            

        }
    }
}
