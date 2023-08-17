using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace e_commerce.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*_).{6,}$", ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one underscore.")]
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public ICollection<Order>? Orders { get; set; }
        //public ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
