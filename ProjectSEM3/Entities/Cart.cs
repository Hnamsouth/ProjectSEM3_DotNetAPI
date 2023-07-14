using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Cart
{
    public int Id { get; set; }

    public int BuyQty { get; set; }

    public int? ProductColorId { get; set; }

    public int? ProductId { get; set; }

    public int? ProductSizeId { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual ProductColor? ProductColor { get; set; }

    public virtual ProductSize? ProductSize { get; set; }

    public virtual User? User { get; set; }
}
