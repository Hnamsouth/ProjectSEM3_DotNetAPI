using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductDto
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

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual CategoryDetail? CategoryDetail { get; set; }

    public virtual ICollection<DiscountProduct> DiscountProducts { get; set; } = new List<DiscountProduct>();

    public virtual ICollection<Favoury> Favouries { get; set; } = new List<Favoury>();

    public virtual KindOfSport? Kindofsport { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ProductForChild> ProductForChildren { get; set; } = new List<ProductForChild>();

    public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
    }
}

