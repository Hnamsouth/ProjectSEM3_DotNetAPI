
using System.ComponentModel.DataAnnotations;

namespace ProjectSEM3.DTOs.Auth
{
    public class UserRegister
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
