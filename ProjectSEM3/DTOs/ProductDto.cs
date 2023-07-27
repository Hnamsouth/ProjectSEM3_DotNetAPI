using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public int? CategoryId { get; set; } // shose , clothing , accessories..

        public int? KindofsportId { get; set; } // FootBall, Running , Training...

        public int? CategoryDetailId { get; set; } // shose: running, tenis , original.. or clothing: t-shirts, hoodies, jackets...

        public byte Gender { get; set; } //  male, female , all

        public DateTime OpenSale { get; set; } 

        public byte Status { get; set; } // open , close , opening soon 

        public virtual ICollection<Cart>? Carts { get; set; } = new List<Cart>();

        public virtual Category? Category { get; set; }

        public virtual ICollection<Favoury>? Favouries { get; set; } = new List<Favoury>();

        public virtual ICollection<OrderDetail>? OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ICollection<ProductColor>? ProductColors { get; set; } = new List<ProductColor>();

        public virtual ICollection<ProductReview>? ProductReviews { get; set; } = new List<ProductReview>();
    }
}

