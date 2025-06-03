using Microsoft.Extensions.Logging;
using BlazorEmailApp.Models;

namespace BlazorEmailApp.Services
{
    // Servizio di invio email simulato per i test
    public class MockEmailService : IEmailService
    {
        private readonly ILogger<MockEmailService> _logger;

        public MockEmailService(ILogger<MockEmailService> logger)
        {
            _logger = logger;
        }

        public Task<bool> SendEmailAsync(EmailMessage message)
        {
            // Simula l'invio dell'email senza effettivamente inviarla
            _logger.LogInformation("SIMULAZIONE: Email inviata a {Recipient}", message.To);
            _logger.LogInformation("SIMULAZIONE: Oggetto: {Subject}", message.Subject);
            _logger.LogInformation("SIMULAZIONE: Corpo: {Body}", message.Body);
            _logger.LogInformation("SIMULAZIONE: HTML: {IsHtml}", message.IsHtml);
            
            // Restituisce sempre successo
            return Task.FromResult(true);
        }
    }
}