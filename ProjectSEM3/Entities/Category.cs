using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CategoryDetail> CategoryDetails { get; set; } = new List<CategoryDetail>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
