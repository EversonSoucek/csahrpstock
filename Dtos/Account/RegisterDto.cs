using System.ComponentModel.DataAnnotations;

namespace csahrpstock.Dtos.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
        
    }
}