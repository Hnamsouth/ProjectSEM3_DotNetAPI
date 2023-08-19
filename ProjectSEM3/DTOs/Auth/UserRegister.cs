
using System.ComponentModel.DataAnnotations;

namespace ProjectSEM3.DTOs.Auth
{
    public class UserRegister
    {
        public int  Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }



    }
}
