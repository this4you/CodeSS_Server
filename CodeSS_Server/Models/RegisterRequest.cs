using System.ComponentModel.DataAnnotations;

namespace CodeSS_Server.Models
{
    public class RegisterRequest
    {
        
        [Required]
        public string Email { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
