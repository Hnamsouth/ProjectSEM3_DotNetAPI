using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int Qty { get; set; }

    public int? OrderId { get; set; }

    public int? ProductSizeId { get; set; }

    public decimal Price { get; set; }

    public string? Img { get; set; }

    public virtual Order? Order { get; set; }

    public virtual ProductSize? ProductSize { get; set; }
}
