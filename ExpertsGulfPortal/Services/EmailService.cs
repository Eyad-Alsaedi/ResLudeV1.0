using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using MailKit.Security;

namespace ExpertsGulfPortal.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string subject, string body)
        {
            var emailMessage = new MimeMessage();

            var fromEmail = _configuration["SmtpSettings:From"];
            var toEmail = _configuration["SmtpSettings:To"];

            if (string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(toEmail))
            {
                throw new ArgumentNullException("Email addresses are not configured properly in appsettings.json.");
            }

            emailMessage.From.Add(new MailboxAddress("ResLude", fromEmail));
            emailMessage.To.Add(new MailboxAddress(" ", toEmail));

            emailMessage.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = body 
            };

            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(fromEmail, _configuration["SmtpSettings:Password"]);
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}
