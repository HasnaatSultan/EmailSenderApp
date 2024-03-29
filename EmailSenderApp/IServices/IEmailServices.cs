using EmailSenderApp.Models;

namespace EmailSenderApp.IServices
{
    public class IEmailServices
    {
        public interface IEmailService
        {
            Task<bool> SendEmailAsync(EmailType type);
        }
    }
}
