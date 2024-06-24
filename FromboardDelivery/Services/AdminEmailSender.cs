using FromboardDelivery.Interfaces;
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

        public async Task SendAsync(IPersonal personal, string subject, string message)
        {
            MailAddress from = new MailAddress(FromEmail, FromName);
            MailAddress to = new MailAddress(personal.Email!);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = message;
            SmtpClient smtp = new SmtpClient(EmailClient);
            smtp.Credentials = credential;
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);

            Console.WriteLine("Письмо отправлено");
        }
    }
}
