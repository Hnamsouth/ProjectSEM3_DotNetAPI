using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs.Auth
{
    public class UserData
    {

        public int? Id { get; set; }

        public string? Email { get; set; } = null!;

        public string? Token { get; set; } = null!;

        public UserInfo? UserInfo { get; set; }
    }
}
