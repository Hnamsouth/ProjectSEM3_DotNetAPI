using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        public int BuyQty { get; set; }

        public int? ProductColorId { get; set; }

        public int? ProductId { get; set; }

        public int? ProductSizeId { get; set; }

        public int? UserId { get; set; }
        public Product? Product { get; set; }
    }
}
