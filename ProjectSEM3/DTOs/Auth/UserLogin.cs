using System.ComponentModel.DataAnnotations;

namespace ProjectSEM3.DTOs.Auth
{
    public class UserLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
