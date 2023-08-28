using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Discount
{
    public int Id { get; set; }

    public string Coupon { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal DiscountPercent { get; set; }

    public string Thumbnail { get; set; } = null!;

    public virtual ICollection<DiscountProduct> DiscountProducts { get; set; } = new List<DiscountProduct>();
}
