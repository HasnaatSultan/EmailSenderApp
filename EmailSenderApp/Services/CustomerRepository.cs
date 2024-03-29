using EmailSenderApp.Models;
using System.Net.Mail;

namespace EmailSenderApp.Services
{
    public class CustomerRepository
    {
        
            private readonly ILogger<CustomerRepository> _logger;
        EmailSender emailSender = new EmailSender();

        public CustomerRepository(ILogger<CustomerRepository> logger)
            {
                _logger = logger;
               
            }

            public async Task<bool> SendCustomerMailAsync(EmailType type)
            {
                try
                {
                    var customers = DataLayer.ListCustomers();
                    var orders = DataLayer.ListOrders();
                string subject;
                string body;
                var customersWithoutOrders = customers.Where(c => orders.Any(o => o.CustomerEmail == c.Email)).ToList();
                foreach (var customer in customersWithoutOrders)
                {
                    switch (type)
                    {
                        case EmailType.Welcome:
                             subject = "Welcome to Our Service";
                             body = $"Dear {customer.Email}, welcome to our service!";
                            break;
                        case EmailType.ComeBack:
                             subject = "We Miss You!";
                             body = $"Dear {customer.Email}, we miss you. Come back soon!";
                            break;

                        default:
                            _logger.LogError($"Unknown email type: {type}");
                            return false;
                    }
                   

                    var message = new Message(new string[] { customer.Email }, subject, body);

                    var addr = new System.Net.Mail.MailAddress(customer.Email);
                    if (addr.Address == customer.Email)
                    {
                        await emailSender.SendEmailAsync(customer.Email , subject, body);
                       
                    }
                }
              

                return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error sending customer mails: {ex.Message}");
                    return false;
                }
            }
        
    }
    }

