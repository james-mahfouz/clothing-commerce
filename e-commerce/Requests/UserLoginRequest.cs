using System.ComponentModel.DataAnnotations;

namespace e_commerce.Requests
{
    public class UserLoginRequest
    {
        [Required, EmailAddress(ErrorMessage = "emailis required")]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
