namespace ProjectSEM3.DTOs
{
    public class CartDto
    {
        public int Id { get; set; }

        public int BuyQty { get; set; }

        public int? ProductId { get; set; }

        public int? ProductSizeId { get; set; }

        public int? UserId { get; set; }
    }
}
