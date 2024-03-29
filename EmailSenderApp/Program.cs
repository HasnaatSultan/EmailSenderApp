using EmailSenderApp.Models;
using EmailSenderApp.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using static EmailSenderApp.IServices.IEmailServices;
using static EmailSenderApp.Services.EmailServices;
using static System.Formats.Asn1.AsnWriter;

namespace EmailSenderApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                config.AddEnvironmentVariables();
            });

            builder.ConfigureServices((hostContext, services) =>
            {
                services.Configure<EmailConfiguration>(hostContext.Configuration.GetSection("EmailConfiguration"));
                services.AddSingleton<IEmailService, EmailService>();
                services.AddSingleton<EmailSender>();
                services.AddSingleton<CustomerRepository>();

                services.AddLogging(config =>
                {
                    config.ClearProviders();
                    config.AddConsole();
                });
            });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    
                   var customerRepository = services.GetRequiredService<CustomerRepository>();

                   
                    var emailService = services.GetRequiredService<IEmailService>();
                    
                    await emailService.SendEmailAsync(EmailType.Welcome);
                    await emailService.SendEmailAsync(EmailType.ComeBack);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while sending email.");
                }
            }

            await host.RunAsync();
        }
    }
    
}
