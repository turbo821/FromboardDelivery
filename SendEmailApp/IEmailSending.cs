using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmailApp
{
    public interface IEmailSending
    {
        Task SendAsync(IPersonal personal, string subject, string message);

    }
}
