using System.ComponentModel.DataAnnotations;

namespace e_commerce.Requests
{
    public class UserRegisterRequest
    {
        [Required, MaxLength(50, ErrorMessage = "first maximum length should be 50")]
        public string FirstName { get; set; } = string.Empty;
        [Required, MaxLength(50, ErrorMessage ="lasst name max lengh is 50")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required, EmailAddress(ErrorMessage ="emailis required")]
        public string Email { get; set; } = string.Empty;
        [Required, MinLength(6, ErrorMessage ="password should have more thne 6 characters")]
        public string Password { get; set; } = string.Empty;
        [Required, Compare("Password", ErrorMessage ="confirm passsword should be the same as the password")]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}
