﻿using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class KindOfSport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product>? Products { get; set; } = new List<Product>();
}
