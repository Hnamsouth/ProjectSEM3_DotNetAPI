using ProjectSEM3.Entities;
using ProjectSEM3.Helpers;

namespace ProjectSEM3.DTOs
{
    public class ProductDemo
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public string? ColorName { get; set; }

        public byte Gender { get; set; }

        public string Img { get; set; } = null!;

        public DateTime OpenSale { get; set; }

        public byte Status { get; set; }

        public int? CategoryDetailId { get; set; }

        public int? KindofsportId { get; set; }
        /*
        public virtual CategoryDetailDto? CategoryDetail { get; set; }

        public virtual KindOfSportDto? Kindofsport { get; set; }
        public virtual CategoryDto? Category { get; set; }*/


    }
}

