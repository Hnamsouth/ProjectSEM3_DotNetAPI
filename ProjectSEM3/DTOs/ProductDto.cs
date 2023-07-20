using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductDto
	{
		public int? Id { get; set; }

		public string Name { get; set; } = null!;

		public decimal Price { get; set; }

		public string? Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual Category? Category { get; set; }

        public virtual ICollection<Favoury> Favouries { get; set; } = new List<Favoury>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();
    }
}

