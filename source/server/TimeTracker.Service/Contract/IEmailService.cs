using System.Threading.Tasks;
using TimeTracker.Domain.Settings;

namespace TimeTracker.Service.Contract
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
