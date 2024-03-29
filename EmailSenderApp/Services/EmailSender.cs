using EmailSenderApp.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using ContentType = MimeKit.ContentType;

namespace EmailSenderApp.Services
{
    public class EmailSender
    {
        

        private readonly EmailConfiguration _emailConfig = new EmailConfiguration();

        public EmailSender(IOptions<EmailConfiguration> emailConfig)
        {
            

            _emailConfig.From = "cs@topcity-1.net";
            _emailConfig.Password = "kmkApple169^";
            _emailConfig.SmtpServer = "smtp.office365.com";
            _emailConfig.UserName = "cs@topcity-1.net";
            _emailConfig.Port = 587;
        }
        public EmailSender()
        {
            

            _emailConfig.From = "cs@TheRightSoftware.net";
            _emailConfig.Password = "kmkApple169^";
            _emailConfig.SmtpServer = "smtp.office365.com";
            _emailConfig.UserName = "cs@topcity-1.net";
            _emailConfig.Port = 587;
        }

        
   

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            try
            {
                using (var client = new System.Net.Mail.SmtpClient(_emailConfig.SmtpServer, _emailConfig.Port))
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(_emailConfig.UserName, _emailConfig.Password);

                    var message = new MailMessage
                    {
                        From = new MailAddress(_emailConfig.UserName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    message.To.Add(to);

                    await client.SendMailAsync(message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }

        


    }
          
    
}

