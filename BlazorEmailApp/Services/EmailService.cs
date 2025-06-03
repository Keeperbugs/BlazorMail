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
                _logger.LogDebug("Preparazione dell'email per {recipient} con oggetto {subject}", message.To, message.Subject);

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

                _logger.LogDebug("Invio email tramite server SMTP {server}:{port}", _smtpSettings.Server, _smtpSettings.Port);

                await client.SendMailAsync(mailMessage);
                _logger.LogInformation("Email inviata con successo a {recipient}", message.To);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Errore durante l'invio dell'email a {recipient}. Oggetto: {subject}", message.To, message.Subject);
                return false;
            }
        }
    }
}