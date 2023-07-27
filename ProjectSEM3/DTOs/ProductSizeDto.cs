using System;
using ProjectSEM3.Entities;

namespace ProjectSEM3.DTOs
{
	public class ProductSizeDto
	{
        public int Id { get; set; }

        public int Qty { get; set; }

        public int? SizeId { get; set; }

        public int? ProductColorId { get; set; }

        public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual ProductColor? ProductColor { get; set; }

        public virtual Size? Size { get; set; }
    }
}

