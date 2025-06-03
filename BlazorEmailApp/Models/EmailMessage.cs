using System.ComponentModel.DataAnnotations; // Aggiungi questa direttiva using

namespace BlazorEmailApp
{
    public class EmailMessage
    {
        [Required(ErrorMessage = "Recipient email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string To { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Subject is required")]
        public string Subject { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Message body is required")]
        public string Body { get; set; } = string.Empty;
        
        public bool IsHtml { get; set; } = false;
    }
}