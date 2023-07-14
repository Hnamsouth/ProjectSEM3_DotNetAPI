using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class ProductColor
{
    public int Id { get; set; }

    public string Img { get; set; } = null!;

    public string? ColorName { get; set; }

    public int? ProductId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Favoury> Favouries { get; set; } = new List<Favoury>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
