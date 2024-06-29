using System.Net;

namespace FromboardDelivery.Interfaces
{
    public interface IEmailSending
    {
        Task SendAsync(IPersonal personal, string subject, string message);
    }
}
