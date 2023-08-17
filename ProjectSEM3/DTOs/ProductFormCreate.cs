using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class ProductFormCreate
    {
        public int? Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; }
        public string? ColorName { get; set; }

        public byte Gender { get; set; }

        public IFormFileCollection? Img { get; set; }

        public DateTime OpenSale { get; set; }

        public byte Status { get; set; }

        public int? CategoryDetailId { get; set; }

        public int? KindofsportId { get; set; }

    }
}

