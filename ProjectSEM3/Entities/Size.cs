﻿using System;
using System.Collections.Generic;

namespace ProjectSEM3.Entities;

public partial class Size
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool Type { get; set; } // true: string, false: number

    public virtual ICollection<ProductSize>? ProductSizes { get; set; } = new List<ProductSize>();
}
