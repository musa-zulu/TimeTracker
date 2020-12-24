using System.ComponentModel.DataAnnotations;

namespace TimeTracker.Domain.Auth
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
