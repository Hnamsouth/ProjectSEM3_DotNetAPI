using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class DiscountProduct
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? DiscountId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public virtual Discount? Discount { get; set; }

    public virtual Product? Product { get; set; }
}
