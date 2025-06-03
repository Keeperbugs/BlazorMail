namespace BlazorEmailApp.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailMessage message);
    }
}