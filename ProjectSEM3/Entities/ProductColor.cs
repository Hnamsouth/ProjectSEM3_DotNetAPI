using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class ProductColor
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ICollection<ProductColorImage> ProductColorImages { get; set; } = new List<ProductColorImage>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}
