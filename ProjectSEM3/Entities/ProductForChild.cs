using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class ProductForChild
{
    public int Id { get; set; }

    public int MinAge { get; set; }

    public int MaxAge { get; set; }

    public int? ProductId { get; set; }

    public virtual Product? Product { get; set; }
}
