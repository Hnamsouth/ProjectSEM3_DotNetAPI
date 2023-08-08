namespace ProjectSEM3.DTOs.Auth
{
    public class AdminDtos
    {
        public int Id { get; set; }

        public string Role { get; set; } = null!;

        public int? UserId { get; set; }
    }
}
