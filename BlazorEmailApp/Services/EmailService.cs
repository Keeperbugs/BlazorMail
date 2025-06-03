using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using BlazorEmailApp.Models;

namespace BlazorEmailApp.Services
{
    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _smtpSettings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<SmtpSettings> smtpSettings, ILogger<EmailService> logger)
        {
            _smtpSettings = smtpSettings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(EmailMessage message)
        {
            try
            {
                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpSettings.SenderEmail, _smtpSettings.SenderName),
                    Subject = message.Subject,
                    Body = message.Body,
                    IsBodyHtml = message.IsHtml
                };

                mailMessage.To.Add(message.To);

                using var client = new SmtpClient(_smtpSettings.Server, _smtpSettings.Port)
                {
                    Credentials = new NetworkCredential(_smtpSettings.Username, _smtpSettings.Password),
                    EnableSsl = _smtpSettings.UseSsl
                };

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email sent successfully to {recipient}", message.To);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send email to {recipient}", message.To);
                return false;
            }
        }
    }
}