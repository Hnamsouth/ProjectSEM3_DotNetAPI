using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class FavoriteDto
    {
        public int? Id { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }
        public Product? Product { get; set; }

    }
}
