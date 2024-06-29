
using MailKit.Net.Smtp;
using MimeKit;
using SendEmailApp;

namespace TestClient
{
    class Program
    {
        public static async Task Main(string[] args)
        {
//            var message = new MimeMessage();
//            message.From.Add(new MailboxAddress("Joey Tribbiani", "joey@friends.com"));
//            message.To.Add(new MailboxAddress("Mrs. Chanandler Bong", "chandler@friends.com"));
//            message.Subject = "How you doin'?";

//            message.Body = new TextPart("plain")
//            {
//                Text = @"Hey Chandler,

//I just wanted to let you know that Monica and I were going to go play some paintball, you in?

//-- Joey"
//            };

//            using (var client = new SmtpClient())
//            {
//                client.Connect("smtp.friends.com", 587, false);

//                // Note: only needed if the SMTP server requires authentication
//                client.Authenticate("joey", "password");

//                client.Send(message);
//                client.Disconnect(true);
//            }

            IEmailSending sender = new AdminEmailSender(new System.Net.NetworkCredential("turbo3735@gmail.com", "lgijyrsemahwqzvp"));
            IPersonal person = new Person(){ Name = "Tomas", Email = "ruinitri30.ru@mail.ru", PhoneNumber = "+7(894)342-43-43" };

            await sender.SendAsync(person, "ТЕст сообщение", "Привет, это тестовое сообщение отправки почты");
        }
    }

    class Person : IPersonal
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
