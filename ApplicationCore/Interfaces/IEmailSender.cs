

using System.Threading.Tasks;

namespace Nika1337.Library.ApplicationCore.Interfaces;

public interface IEmailSender
{
    Task<bool> SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
}
