using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class CategoryDetail
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
