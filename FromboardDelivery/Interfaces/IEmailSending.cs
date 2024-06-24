using System.Net;

namespace FromboardDelivery.Interfaces
{
    public interface IEmailSending
    {
        string FromEmail { get; set; }
        string FromName { get; set; }
        string ToEmail { get; set; }
        string EmailClient { get; set; }
        Task SendAsync(IPersonal personal, string subject, string message);

    }
}
