using System.ComponentModel.DataAnnotations;

namespace SecureShop.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$",
         ErrorMessage = "Password must have uppercase, number, and special char.")]
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "Customer"; // Default role
    }
}
