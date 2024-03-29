using EmailSenderApp.Models;
using static EmailSenderApp.IServices.IEmailServices;

namespace EmailSenderApp.Services
{
    public class EmailServices
    {
        public class EmailService : IEmailService
        {
            private readonly ILogger<EmailService> _logger;
            private readonly EmailSender _emailSender;
            private readonly CustomerRepository _customerRepository;

            public EmailService(ILogger<EmailService> logger, EmailSender emailSender, CustomerRepository customerRepository)
            {
                _logger = logger;
                _emailSender = emailSender;
                _customerRepository = customerRepository;
            }

            public async Task<bool> SendEmailAsync(EmailType type)
            {
                try
                {
                    
                    await _customerRepository.SendCustomerMailAsync( type);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error sending email: {ex.Message}");
                    return false;
                }
            }
        }
    }
}
